using System;
using System.Collections.Generic;
using Actemium.ApplicationSettings.Model;
using Actemium.Diagnostics;

namespace Actemium.ApplicationSettings.Business
{
  public partial class ApplicationSettings
  {
    private List<ApplicationSetting> _settings = new DataAccess.ApplicationSettings().GetAll();
    private List<ApplicationSettingsCategory> _categories = new DataAccess.ApplicationSettingsCategories().GetAll();

    public string this[string category, string name]
    {
      get
      {
        var categoryId = _categories.Find(x => x.Name.Equals(category))?.ApplicationSettingsCategoryId;
        return categoryId.HasValue ? this[categoryId.Value, name] : null;
      }
    }

    public string this[int categoryId, string name]
    {
      get
      {
        return _settings.Find(x => x.Name.Equals(name) && x.ApplicationSettingsCategoryId == categoryId)?.Value;
      }
    }

    public string this[int id]
    {
      get { return _settings.Find(x => x.ApplicationSettingId == id)?.Value; }
    }

    public void InvalidateCache()
    {
      _settings = new DataAccess.ApplicationSettings().GetAll();
      _categories = new DataAccess.ApplicationSettingsCategories().GetAll();
    }

    /// <summary>
    /// Equals function to compare class
    /// </summary> 
    public bool Exists(String applicationSettingName)
    {
      try
      {
        DataAccess.ApplicationSettings applicationSettings = new DataAccess.ApplicationSettings();
        return applicationSettings.GetAll().Find(x => x.Name.Equals(applicationSettingName, StringComparison.InvariantCultureIgnoreCase)) != null;
      }
      catch (Exception ex)
      {
        Trace.WriteError("{0}", Trace.GetMethodName(), CLASSNAME, ex, applicationSettingName);
        throw;
      }
    }
  }
}
