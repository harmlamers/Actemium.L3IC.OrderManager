using System;
using System.Drawing;
using System.Windows.Forms;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.UserManagement2;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
  public partial class PopupHelp : BasePopupForm
  {
    private const string CLASSNAME = nameof(PopupHelp);
    

    public PopupHelp()
    {
      Visible = false;
      InitializeComponent();
      

      pnlBusy.Enabled = true;
      pnlBusy.Visible = true;
      pnlNotFound.Enabled = false;
      pnlNotFound.Visible = false;

      pnlBusy.Location = new Point((Size.Width - pnlBusy.Size.Width) / 2, (Size.Height - pnlBusy.Size.Height) / 2);
      pnlNotFound.Location = new Point((Size.Width - pnlNotFound.Size.Width) / 2, (Size.Height - pnlNotFound.Size.Height) / 2);

      ShowHelp();
    }

    private void ShowHelp()
    {
      try
      {
        var root = CurrentUser.GetComputerProperty((int) UserManagementProperties.ComputerPathToServerRoot).Value;
        var manualLocation = ApplicationSettings.Business.ApplicationSettings.Instance[(int)L3IC.OrderManager.General.Enums.ApplicationSettings.HelpLocation];
        var helpLocation = $"{root}{manualLocation}";

        if (!string.IsNullOrEmpty(helpLocation))
        {
          webBrowser.Navigate(helpLocation);
        }
        else
        {
          DisplayError(TranslationKey.Error_Help_NoHelpDefined, "There is no correct Help Page defined.", "Help page not found");
          Close();
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private void AlarmHelpBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      pnlBusy.Enabled = false;
      pnlBusy.Visible = false;
    }
    

    private void AlarmHelpBrowserProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
    {
      if (e.CurrentProgress == e.MaximumProgress)
      {
        pnlBusy.Enabled = false;
        pnlBusy.Visible = false;
        
        Trace.WriteVerbose(webBrowser.StatusText,Trace.GetMethodName(), CLASSNAME);

        if (webBrowser.StatusText.Equals("Done") && !webBrowser.Url.Equals(new Uri("about:blank"))) //It returns string.empty when successfull and Done when failed....
        {
          webBrowser.Navigate("about:blank");
          pnlNotFound.Enabled = true;
          pnlNotFound.Visible = true;
        }
      }
    }
  }
}
