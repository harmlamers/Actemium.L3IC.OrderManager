using System.Collections;
using System.Configuration;
using System.Linq;

namespace Actemium.L3IC.OrderManager.General.Configuration
{

  public sealed class NavigationTabItemCollection : ConfigurationElementCollection
  {
    protected override ConfigurationElement CreateNewElement()
    {
      return new NavigationTabItem();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((NavigationTabItem)element).Name;
    }

    public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;

    protected override string ElementName => "TabItem";

    public new NavigationTabItem this[string name]
    {
      get
      {
        IEnumerator enumerator = GetEnumerator();
        while (enumerator.MoveNext())
        {
          var item = (NavigationTabItem)enumerator.Current;
          if (item?.Name == name)
            return item;
        }
        return null;
      }
    }

    public bool ContainsKey(int key)
    {
      object[] keys = BaseGetAllKeys();
      return keys.Any(obj => (int) obj == key);
    }
  }
}
