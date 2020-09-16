using System;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.CommunicatorERP.ERPMessageHandlers;
using Actemium.L3IC.OrderManager.CommunicatorERP.ERPMessages;
using Actemium.Services.WCF;

namespace CommunicatorERP
{
  internal class ERPImportWorker : WorkerThreadBase
  {
    // MHL : Paden niet in constanten zetten maar uit de App.Config lezen, dat wijzigt namelijk gegarandeerd nog, al is het maar om van test naar productie te komen
    private readonly string _path;
    private readonly string _pathError;
    private readonly string _pathSuccess;
    private readonly string _usedExtension;

    public bool GlobalError { get; set; }

    private DateTime _time;
    private int _timeTick = 0;

    public ERPImportWorker() : base(nameof(ERPImportWorker))
    {
      _path = ConfigurationManager.AppSettings["Path"];
      _pathError = ConfigurationManager.AppSettings["ErrorPath"];
      _pathSuccess = ConfigurationManager.AppSettings["SuccessPath"];
      _usedExtension = ConfigurationManager.AppSettings["UsedExtension"];

      GlobalError = false;
    }

    protected override void WorkerThreadFunction()
    {
      //Not nescessary
    }

    protected override bool WorkerThreadFunctionIsKicking()
    {
        _time = DateTime.Now;

        if (_time.Second % 5 == 0)
        {
          if (_timeTick == 0)
          {
            _timeTick++;
            return ReadDirectory();
          }
        }
        else
        {
          _timeTick = 0;
        }

      return base.WorkerThreadFunctionIsKicking();
    }

    private bool ReadDirectory()
    {
      if (Directory.Exists(_path))
      {
        GlobalError = false;
        return ProcessDirectory(_path);
      }
      else
      {
        if (GlobalError == true)
        {
          // let op met deze constructie, je krijgt nu als het niet goed geconfigureerd is elke 5 seconden een fout in je tracefile
          Trace.WriteError($"Directory {_path} does not exist", Trace.GetMethodName(), CLASSNAME);
          GlobalError = true;
        }
        return false;
      }
    }

    private bool ProcessDirectory(string targetDirectory)
    {
      string[] fileEntries = Directory.GetFiles(targetDirectory);

      foreach (string filename in fileEntries)
      {
        if (CheckFileExtension(filename))
        {
          HandleFileToOrder(filename);
        }
      }

      return true;
    }

    private bool CheckFileExtension(string filename)
    {
      // deze controle garardeerd niet dat files *.xml zijn. Zou ook *.xml.error kunnen zijn.
      //return filename.LastIndexOf(_usedExtension) > 0 || filename.LastIndexOf(_usedExtension.ToUpper()) > 0;
      // MHL: er is een handige klasse die je hiervoor kunt gebruiken, er zitten nog meer handige functies in voor filenamen
      // bijv: Path.GetExtension(fileName);
      return Path.GetExtension(filename) == _usedExtension;
    }

    private void HandleFileToOrder(string filename)
    {
      bool hasError = true;

      XmlSerializer serializer = new XmlSerializer(typeof(Message));
      serializer.UnknownNode += Serializer_UnknownNode;
      serializer.UnknownAttribute += Serializer_UnknownAttribute;

      // MHL: Let op, als er iets mis gaat tussen het aanmaken van de stream en je try blok dan wordt de finally niet aangeroepen
      // gebruik liever een using blok, daar zit een implicite finally in.
      using (FileStream fs = new FileStream(filename, FileMode.Open))
      {
        Message orderMessage = new Message();
        OrderHandler orderHandler = new OrderHandler();

        try
        {
          orderMessage = (Message)serializer.Deserialize(fs);
          orderHandler.OrderMessage = orderMessage;

          hasError = orderHandler.HandleMessage();
        }
        catch (Exception ex)
        {
          // MHL : nu wordt de exceptie niet mee getraced, was dat de bedoeling?
          Trace.WriteError($"Error in file {filename}", Trace.GetMethodName(), CLASSNAME, ex);
        }

        
      }

      if (hasError)
      {
        MoveFile(filename, _pathError);
      }
      else
      {
        MoveFile(filename, _pathSuccess);
      }

    }

    private void MoveFile(string fromFilePath , string toPath)
    {
      string toFilePath = "";
      // MHL : ook hier kan de Path classe makkelijk zijn.  Path.GetFileName(fromFilePath) en Path.GetFileNameWithoutExtension()
      // MHL : ik zou hier een try catch omheen zetten zodat duidelijker is dat de fout pas optreedt na het inlezen, eventueel rethrow
      try
      {
        string filename = Path.GetFileNameWithoutExtension(fromFilePath) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fromFilePath);
        toFilePath = toPath + @"\" + filename;

        File.Move(fromFilePath, toFilePath);
      }
      catch (Exception ex)
      {
        Trace.WriteError($"Moving file {fromFilePath} to {toFilePath} is not possible", Trace.GetMethodName(), CLASSNAME, ex);
      }
        

    }

    private void Serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
    {
      System.Xml.XmlAttribute attributeWithError = e.Attr;

      Trace.WriteError($"XML has been altered with unknown attribute: {attributeWithError.Name} = '{attributeWithError.Value}'", Trace.GetMethodName(), CLASSNAME);
    }

    private void Serializer_UnknownNode(object sender, XmlNodeEventArgs e)
    {
      Trace.WriteError($"XML has been altered with unknown node: {e.Name}, {e.Text}", Trace.GetMethodName(), CLASSNAME);
    }
  }
}
