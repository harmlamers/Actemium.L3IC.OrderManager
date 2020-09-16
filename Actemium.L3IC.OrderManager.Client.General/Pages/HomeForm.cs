using System;
using System.Drawing;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Enums;

namespace Actemium.L3IC.OrderManager.Client.General.Pages
{
  public partial class HomeForm : BasePageForm
	{
		public HomeForm()
		{
			InitializeComponent();

			NavigationItem = NavigationItems.Home;
			Title = "Welcome";
		}

	  public override void Refresh()
	  {
	    base.Refresh();
	    HomeFormResize(null, EventArgs.Empty);
	  }

	  private void HomeFormResize(object sender, EventArgs e)
		{
			logoPictureBox.Location = new Point((Size.Width - logoPictureBox.Size.Width) / 2, (Size.Height - logoPictureBox.Size.Height) / 12 * 2);
			welcomeLabel.Location = new Point((Size.Width - welcomeLabel.Size.Width) / 2, (Size.Height - welcomeLabel.Size.Height) / 12 * 9);
		}

        private void BtOpenTestFormClick(object sender, EventArgs e)
        {
            GlobalHandler.MainForm.Navigate(NavigationItems.Test);
        }

    private void HomeFormLoad(object sender, EventArgs e)
    {
      string applicationName = "Actemium " + ApplicationSettings.Business.ApplicationSettings.Instance[(Int32)L3IC.OrderManager.General.Enums.ApplicationSettings.ApplicationName];
      welcomeLabel.Text = String.Format(Translations.HomeForm.WelcomeLabel, applicationName);
   
    }
  }
}
