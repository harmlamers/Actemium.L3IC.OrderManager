using System;
using System.Collections;
using System.Configuration;
using System.Linq;

namespace Actemium.L3IC.OrderManager.General.Configuration
{

  public sealed class NavigationTabItem : ConfigurationElementCollection
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

    [ConfigurationProperty("keyTips", IsRequired = false, DefaultValue = "")]
    public string KeyTips
    {
      get => (string)base["keyTips"];
      set => base["keyTips"] = value;
    }

    [ConfigurationProperty("tag", IsRequired = false, DefaultValue = "")]
    public string Tag
    {
      get => (string)base["tag"];
      set => base["tag"] = value;
    }

    [ConfigurationProperty("image", IsRequired = false, DefaultValue = null)]
    public string Image
    {
      get => (string)base["image"];
      set => base["image"] = value;
    }

    [ConfigurationProperty("accessControlItem", IsRequired = false, DefaultValue = null)]
    // ReSharper disable once InconsistentNaming
    public string ACI_string
    {
      get => (string)base["accessControlItem"];
      set => base["accessControlItem"] = value;
    }

    [ConfigurationProperty("displayOrder", IsRequired = false, DefaultValue = -1)]
    public Int32 DisplayOrder
    {
      get => (Int32)base["displayOrder"];
      set => base["displayOrder"] = value;
    }

    public string[] ACI
    {
      get 
      {
        if (!string.IsNullOrEmpty(ACI_string))
          return ACI_string.Split(';');
        
        return null;
      }
      set => ACI_string = value == null ? "" : String.Join(";", value);
    }

    protected override ConfigurationElement CreateNewElement()
    {
      return new NavigationTabBar();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((NavigationTabBar)element).Name;
    }

    public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;

    protected override string ElementName => "TabBar";

    public new NavigationTabBar this[string name]
    {
      get
      {
        IEnumerator enumerator = GetEnumerator();
        while (enumerator.MoveNext())
        {
          var item = (NavigationTabBar)enumerator.Current;
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
      return
        $"NavigationTabItem:Name='{Name}',KeyTips='{KeyTips}',Tag='{Tag}',Image='{Image}', TabBars='{Count.ToString()}', DisplayOrder='{DisplayOrder.ToString()}'";
    }
  }
}
