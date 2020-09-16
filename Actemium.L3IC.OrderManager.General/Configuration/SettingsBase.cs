using System;
using System.Configuration;
using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.General.Configuration
{
#pragma warning disable RCS1102 // Make class static.
  public class SettingsBase
#pragma warning restore RCS1102 // Make class static.
  {
    private const string CLASSNAME = nameof(SettingsBase);

    #region AppConfig Handling
    static SettingsBase()
    {
      Trace.WriteVerbose("", Trace.GetMethodName(), CLASSNAME);
      try
      {
        ACT = (ConfigHandler)ConfigurationManager.GetSection("ACT");
        if(ACT == null)
          throw new ConfigurationErrorsException("Can not find section 'ACT' in App.Config");
      }
      catch (Exception ex)
      {
        Trace.WriteError("Unable to parse Configuration.", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    public static ConfigHandler ACT { get; }

    

    #endregion
  }
}
