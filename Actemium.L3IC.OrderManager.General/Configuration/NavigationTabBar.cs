using System;
using System.Collections;
using System.Configuration;
using System.Linq;

namespace Actemium.L3IC.OrderManager.General.Configuration
{

  public sealed class NavigationTabBar : ConfigurationElementCollection
  {
    [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
    public string Name
    {
      get => (string)base["name"];
      set => base["name"] = value;
    }

		[ConfigurationProperty("text", IsRequired = true)]
		public string Text
		{
			get => (string)base["text"];
		  set => base["text"] = value;
		}

    [ConfigurationProperty("showName", IsRequired = false, DefaultValue=false)]
    public bool ShowName
    {
      get => (bool)base["showName"];
      set => base["showName"] = value;
    }

    [ConfigurationProperty("displayOrder", IsRequired = false, DefaultValue = -1)]
    public Int32 DisplayOrder
    {
      get => (Int32)base["displayOrder"];
      set => base["displayOrder"] = value;
    }

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


    public override string ToString()
    {
      return $"NavigationTabBar:Name='{Name}', TabItems='{Count.ToString()}'";
    }
  }
}
