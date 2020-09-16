using System;
using Actemium.L3IC.OrderManager.Client.General.Enums;

namespace Actemium.L3IC.OrderManager.Client.General.Events
{

	public class ScreenChangedEventArgs : EventArgs
	{
	  public ScreenChangedEventArgs(NavigationItems screen)
		{
			Screen = screen;
		}

		public NavigationItems Screen { get; }
	}
}
