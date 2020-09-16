using System.Configuration;
using System.Diagnostics;

// Disable incorrect compiler warning "Missing XML comment for ..."
#pragma warning disable 1591

namespace Actemium.History.Configuration
{
  /// <summary>
  /// Configuration section handler within the configuration section to configure the SecuritySettings
  /// </summary>
  public sealed class HISTConfigHandler : ConfigurationSection
  {
    /// <summary>
    /// Default Constructor
    /// </summary>
    // ReSharper disable EmptyConstructor
    public HISTConfigHandler()
    {
    }
    // ReSharper restore EmptyConstructor
    
    /// <summary>
    /// The connection string to the HISTDB database
    /// </summary>
		[ConfigurationProperty("connectionStringHISTDB", IsRequired = false, DefaultValue = "")]
    public string ConnectionStringHISTDB
    {
      get => (string)this["connectionStringHISTDB"];
      set => this["connectionStringHISTDB"] = value;
    }

    /// <summary>
    /// Default show action in client
    /// </summary>
    [ConfigurationProperty("ShowActionsInClientDefault", IsRequired = false, DefaultValue = "true")]
    public bool ShowActionsInClientDefault
    {
      get => (bool)this["ShowActionsInClientDefault"];
      set => this[nameof(ShowActionsInClientDefault)] = value;
    }

    /// <summary>
    /// Default save action in database
    /// </summary>
    [ConfigurationProperty("SaveActionsInDatabaseDefault", IsRequired = false, DefaultValue = "true")]
    public bool SaveActionsInDatabaseDefault
    {
      get => (bool)this["SaveActionsInDatabaseDefault"];
      set => this[nameof(SaveActionsInDatabaseDefault)] = value;
    }

    /// <summary>
    /// Default trace level
    /// </summary>
    [ConfigurationProperty("TraceLevelDefault", IsRequired = false, DefaultValue = "Verbose")]
    public SourceLevels TraceLevelDefault
    {
      get => (SourceLevels)this["TraceLevelDefault"];
      set => this[nameof(TraceLevelDefault)] = value;
    }

    [ConfigurationProperty("LogTypeID", IsRequired = false, DefaultValue = 1)]
    public int LogTypeID
    {
      get => (int)this["LogTypeID"];
      set => this[nameof(LogTypeID)] = value;
    }

    public override string ToString()
    {
      return "HISTConfigHandler:()";
    }
  }
}

#pragma warning restore 1591
