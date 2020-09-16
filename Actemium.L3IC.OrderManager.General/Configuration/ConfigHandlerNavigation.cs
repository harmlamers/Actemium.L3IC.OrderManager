using System.Configuration;

namespace Actemium.L3IC.OrderManager.General.Configuration
{
#pragma warning disable RCS1060 // Declare each type in separate file.
  public sealed class ConfigHandlerNavigation : ConfigurationSection
#pragma warning restore RCS1060 // Declare each type in separate file.
  {
    [ConfigurationProperty("TabItems")]
    public NavigationTabItemCollection TabItems => (NavigationTabItemCollection)this["TabItems"];
  }
}
