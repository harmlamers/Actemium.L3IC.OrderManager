using System;
using System.Collections.Generic;
using System.Xml;
using Actemium.Diagnostics;
using Actemium.History.Model;

namespace Actemium.History.Business
{
  public partial class HistoryActions
  {
    /// <summary>
    /// Adds history action
    /// </summary>
    /// <param name="historyActionKey">The action key</param>
    /// <param name="timeStampUTC">The timestamp</param>
    /// <param name="userId">The userId</param>
    /// <param name="computerId">The computerId</param>
    /// <param name="parameters">The parameters of the message</param>
    /// <returns>True if history action is configured to be shown in the client</returns>
    public bool AddHistoryAction(
      string historyActionKey, string traceMessage, DateTime timeStampUTC, int? userId, int? computerId, params object[] parameters)
    {
      var historyKey = HistoryKeys.Instance.GetOrAddHistoryKey(historyActionKey);

      switch (historyKey.TraceLevelValue)
      {
        case System.Diagnostics.SourceLevels.Off:
          break;
        case System.Diagnostics.SourceLevels.Critical:
          Trace.WriteCritical(traceMessage, Trace.GetMethodName(), CLASSNAME, parameters);
          break;
        case System.Diagnostics.SourceLevels.Error:
          Trace.WriteError(traceMessage, Trace.GetMethodName(), CLASSNAME, parameters);
          break;
        case System.Diagnostics.SourceLevels.Warning:
          Trace.WriteWarning(traceMessage, Trace.GetMethodName(), CLASSNAME, parameters);
          break;
        case System.Diagnostics.SourceLevels.Information:
          Trace.WriteInformation(traceMessage, Trace.GetMethodName(), CLASSNAME, parameters);
          break;
        case System.Diagnostics.SourceLevels.Verbose:
          Trace.WriteVerbose(traceMessage, Trace.GetMethodName(), CLASSNAME, parameters);
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }

      if (historyKey.SaveInDatabase)
      {
        var parameterXML = Parameters2XML(parameters);
        var action = new HistoryAction(-1, historyKey.HistoryKey, timeStampUTC, userId, computerId, parameterXML);
        Add(action);
      }
      
      return historyKey.ShowInClient;
    }

    private string Parameters2XML(object[] parameters)
    {
      XmlDocument doc = new XmlDocument
      {
        PreserveWhitespace = true
      };
      XmlElement parameterElement = (XmlElement)doc.AppendChild(doc.CreateElement("Parameters"));

      int n = 0;
      foreach (var parameter in parameters)
      {
        parameterElement.AppendChild(doc.CreateElement($"Parameter{n.ToString()}")).InnerText = parameter.ToString();
        n++;
      }

      return doc.InnerXml;
    }

    internal List<object> XML2Parameters(string xml)
    {
      List<object> result = new List<object>();
      XmlDocument doc = new XmlDocument
      {
        PreserveWhitespace = true
      };
      doc.LoadXml(xml);
      var parameterElement = doc.DocumentElement;
      if (parameterElement == null)
        return null;

      foreach (XmlElement parameter in parameterElement.ChildNodes)
      {
        result.Add(parameter.InnerText);
      }

      return result;
    }
  }
}
