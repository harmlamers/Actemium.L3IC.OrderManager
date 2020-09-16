using System;
using System.Collections;
using System.Configuration;
using System.Linq;

namespace Actemium.L3IC.OrderManager.General.Configuration
{
#pragma warning disable RCS1060 // Declare each type in separate file.
  public sealed class ConfigHandler : ConfigurationSection
#pragma warning restore RCS1060 // Declare each type in separate file.
  {
    [ConfigurationProperty("environmentName", IsRequired = false)]
    public string EnvironmentName
    {
      get => (string)base["environmentName"];
      set => base["environmentName"] = value;
    }

    [ConfigurationProperty("isProduction", IsRequired = false, DefaultValue = true)]
    public bool IsProduction
    {
      get => (bool)base["isProduction"];
      set => base["isProduction"] = value;
    }
  }

#pragma warning disable RCS1060 // Declare each type in separate file.
  public sealed class ConnectionCollection : ConfigurationElementCollection
#pragma warning restore RCS1060 // Declare each type in separate file.
  {
    protected override ConfigurationElement CreateNewElement()
    {
      return new ConnectionString();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((ConnectionString)element).Name;
    }

    public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;

    protected override string ElementName => "ConnectionString";

    /// <summary>
    /// Get a ConnectionString by name
    /// </summary>
    /// <param name="name">The name of the ConnectionString to be found</param>
    /// <returns>The ConnectionString object with the corresponding name</returns>
    public new ConnectionString this[string name]
    {
      get
      {
        IEnumerator enumerator = GetEnumerator();
        while (enumerator.MoveNext())
        {
          var param = (ConnectionString)enumerator.Current;
          if (param?.Name == name)
            return param;
        }
        return null;
      }
    }

    /// <summary>
    /// Returns true when the collection contains the key
    /// </summary>
    /// <param name="key">The key</param>
    /// <returns>True when the collections contains the key</returns>
    public bool ContainsKey(string key)
    {
      object[] keys = BaseGetAllKeys();
      return keys.Any(obj => (string)obj == key);
    }
  }

#pragma warning disable RCS1060 // Declare each type in separate file.
                               /// <summary>
                               /// A parameter present in the application configuration
                               /// </summary>
  public sealed class ConnectionString : ConfigurationElement
#pragma warning restore RCS1060 // Declare each type in separate file.
  {
    /// <summary>
    /// Default Constructor
    /// </summary>
    // ReSharper disable EmptyConstructor
    public ConnectionString()
    { }
    // ReSharper restore EmptyConstructor

    /// <summary>
    /// The Name of the parameter
    /// </summary>
    [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
    public string Name
    {
      get => (string)this["name"];
      set => this["name"] = value;
    }

    /// <summary>
    /// The Value of the parameter
    /// </summary>
    [ConfigurationProperty("value", IsRequired = true, IsKey = true)]
    public string Value
    {
      get => (string)this["value"];
      set => this["value"] = value;
    }

    public override string ToString()
    {
      return $"ConnectionString:Name='{Name}',Value='{Value}'";
    }
  }
}
