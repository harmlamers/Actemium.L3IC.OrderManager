using System;
using System.Linq;
using Actemium.L3IC.OrderManager.Client.General.Enums;

namespace Actemium.L3IC.OrderManager.Client.General.ExtensionMethods
{
  public static class NavigationItemsExtensionMethods
	{

		/// <summary>
		/// Get NavigationGroup from the given NavigationItem
		/// </summary>
		/// <param name="eEnum"></param>
		/// <returns></returns>
		public static NavigationItemGroups GetGroup(this NavigationItems eEnum)
		{
			int value = ((int)eEnum / 100);
			if (Enum.IsDefined(typeof(NavigationItemGroups), value))
        return (NavigationItemGroups)value;

      return NavigationItemGroups.Unknown;
		}

		/// <summary>
		/// Get "ExcludeFromStack" Attribute returns true if it was definied for the given NavigationItem
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool GetExcludeFromStack(this NavigationItems value)
		{
			// Check for Enum that is marked with FlagAttribute
			var fieldInfo = value.GetType().GetField(value.ToString().Trim());
			var attributes = (ExcludeFromNavigationStackAttribute[]) fieldInfo.GetCustomAttributes(typeof(ExcludeFromNavigationStackAttribute), false);
			return attributes.Any();
		}

	}
}
