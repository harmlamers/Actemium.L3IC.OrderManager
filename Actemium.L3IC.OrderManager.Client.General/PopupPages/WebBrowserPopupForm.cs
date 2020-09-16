using System;
using System.Drawing;
using System.Windows.Forms;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.General.Translations;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
  public partial class WebBrowserPopupForm : BasePopupForm
  {
		private const string CLASSNAME = nameof(WebBrowserPopupForm);

	  private readonly String _webPageURL;

		public WebBrowserPopupForm(String webPageURL)
    {
      Visible = false;
      InitializeComponent();

			_webPageURL = webPageURL;

      busyPanel.Enabled = true;
      busyPanel.Visible = true;
      notFoundPanel.Enabled = false;
      notFoundPanel.Visible = false;

      busyPanel.Location = new Point((Size.Width - busyPanel.Size.Width) / 2, (Size.Height - busyPanel.Size.Height) / 2);
      notFoundPanel.Location = new Point((Size.Width - notFoundPanel.Size.Width) / 2, (Size.Height - notFoundPanel.Size.Height) / 2);

      ShowWebPage();
    }

    private void ShowWebPage()
    {
      try
      {
        if (!string.IsNullOrEmpty(_webPageURL))
        {
          webBrowser.Navigate(_webPageURL);
        }
        else
        {
          DisplayWarning(TranslationKey.Message_HelpForAlarmNotFound, "Page not found", "No (correct) page is configured for this item");
          Close();
        }
      }
      catch (Exception ex)
      {
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

	  private void WebBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
	    try
	    {
				busyPanel.Enabled = false;
				busyPanel.Visible = false;
			}
	    catch (Exception ex)
	    {
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
			}
    }

    private void WebBrowserProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
    {
	    try
	    {
	      if (e.CurrentProgress != e.MaximumProgress)
          return;

        busyPanel.Enabled = false;
	      busyPanel.Visible = false;

	      if (webBrowser.Document != null)
          return;

        webBrowser.Navigate("");
	      notFoundPanel.Enabled = true;
	      notFoundPanel.Visible = true;
	    }
	    catch (Exception ex)
	    {
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
			}
    }
  }
}