using System;
using System.Configuration;
using System.Diagnostics;

namespace Actemium.History.Configuration
{
  /// <summary>
  /// Settings Class used internally
  /// </summary>
  internal sealed class SettingsHIST
  {
    /// <summary>
    /// The ConnectionStringHISTDB within the History Section
    /// </summary>
    public static String ConnectionStringHISTDB { get; }

    /// <summary>
    /// Default show action in client
    /// </summary>
    public static Boolean ShowActionsInClientDefault { get; }

    /// <summary>
    /// Default save action in database
    /// </summary>
    public static Boolean SaveActionsInDatabaseDefault { get; }

    /// <summary>
    /// Default trace level
    /// </summary>
    public static SourceLevels TraceLevelDefault { get; }


    /// <summary>
    /// The History configuration
    /// </summary>
    static SettingsHIST()
    {
      var section = (HISTConfigHandler)ConfigurationManager.GetSection("HISTSettings");
      if (section == null)
        throw new ConfigurationErrorsException("Can not find section 'HISTSettings' in App.Config");


      ConnectionStringHISTDB = section.ConnectionStringHISTDB;
      ShowActionsInClientDefault = section.ShowActionsInClientDefault;
      SaveActionsInDatabaseDefault = section.SaveActionsInDatabaseDefault;
      TraceLevelDefault = section.TraceLevelDefault;
    }
  }
}
