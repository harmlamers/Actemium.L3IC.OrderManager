using System;
using System.Drawing;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Enums;

namespace Actemium.L3IC.OrderManager.Client.General.Pages
{
  public partial class ErrorForm : BasePageForm
	{
		public ErrorForm(bool error)
		{
			InitializeComponent();
      Translations.Initialize();

			NavigationItem = NavigationItems.Error;
			Title = "Error";

			errorLabel.Text = error ? Translations.ErrorForm.UnknownError : Translations.ErrorForm.PageNotFound;
		}

		private void ErrorFormResize(object sender, EventArgs e)
		{
			errorLabel.Location = new Point((Size.Width - errorLabel.Size.Width) / 2, (Size.Height - errorLabel.Size.Height) / 2);
		}
	}
}