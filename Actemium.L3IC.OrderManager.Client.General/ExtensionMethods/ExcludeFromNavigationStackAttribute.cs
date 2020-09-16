using System;

namespace Actemium.L3IC.OrderManager.Client.General.ExtensionMethods
{

  [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
  /// <summary>
  /// Attribute used for NavigationItems to exclude the screen from the navigation stack
  /// </summary>
  public class ExcludeFromNavigationStackAttribute : Attribute
	{
	}
}
