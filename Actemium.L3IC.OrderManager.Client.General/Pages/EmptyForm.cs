using System;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Enums;

namespace Actemium.L3IC.OrderManager.Client.General.Pages
{
  public partial class EmptyForm : BasePageForm
	{
		public EmptyForm()
		{
			InitializeComponent();

			NavigationItem = NavigationItems.EmptyForm;
			Title = "Welcome";
		}

	  public override void Refresh()
	  {
	    base.Refresh();
      EmptyFormResize(null, EventArgs.Empty);
	  }

	  private void EmptyFormResize(object sender, EventArgs e)
		{
			
		}
  }
}
