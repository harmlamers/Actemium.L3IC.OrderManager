using System.Configuration;

// Disable incorrect compiler warning "Missing XML comment for ..."
#pragma warning disable 1591

namespace Actemium.ApplicationSettings.Configuration
{
  /// <summary>
  /// Configuration section handler within the configuration section to configure the SecuritySettings
  /// </summary>
  public sealed class ASConfigHandler : ConfigurationSection
  {
    /// <summary>
    /// Default Constructor
    /// </summary>
    // ReSharper disable EmptyConstructor
    public ASConfigHandler()
    {
    }
    // ReSharper restore EmptyConstructor
    
    /// <summary>
    /// The connection string to the ASDB database
    /// </summary>
		[ConfigurationProperty("connectionStringASDB", IsRequired = false, DefaultValue = "")]
    public string ConnectionStringASDB
    {
      get => (string)this["connectionStringASDB"];
      set => this["connectionStringASDB"] = value;
    }

    [ConfigurationProperty("LogTypeID", IsRequired = false, DefaultValue = 1)]
    public int LogTypeID
    {
      get => (int)this["LogTypeID"];
      set => this[nameof(LogTypeID)] = value;
    }

    public override string ToString()
    {
      return "ASConfigHandler:()";
    }
  }
}

#pragma warning restore 1591
