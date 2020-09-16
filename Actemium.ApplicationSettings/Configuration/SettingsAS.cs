using System;
using System.Configuration;

namespace Actemium.ApplicationSettings.Configuration
{
  /// <summary>
  /// Settings Class used internally
  /// </summary>
  internal sealed class SettingsAS
  {
    /// <summary>
    /// The ConnectionStringASDB within the ApplicationSettings Section
    /// </summary>
    public static String ConnectionStringASDB { get; }


    /// <summary>
    /// The ApplicationSettings configuration
    /// </summary>
    static SettingsAS()
    {
      var section = (ASConfigHandler)ConfigurationManager.GetSection("ASSettings");
      if (section == null)
        throw new ConfigurationErrorsException("Can not find section 'ASSettings' in App.Config");


      ConnectionStringASDB = section.ConnectionStringASDB;
    }
  }
}
