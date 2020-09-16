using System;
using System.ComponentModel;
using Actemium.Translations;
using Actemium.Windows.Forms.DevComponents2.Interfaces;

namespace Actemium.L3IC.OrderManager.Client.General.Base.PropertyGrids
{
  public class PropertyGridElement : IDisposable, IInitializeControl, ITranslatableControl
  {
    public string Name;
    public string Value;
    public string Category;
    public string Description;
    private bool _disposed;
    private bool _initialized;

    public static PropertyGridElement NoData => new PropertyGridElement(Translations.PropertyGridElements.NoData, Translations.PropertyGridElements.Unknown, "", "", false);

    [Browsable(true)]
    [System.ComponentModel.Category("Actemium")]
    [System.ComponentModel.Description("Do not translate this control if set to false")]
    public bool Translate { get; set; }

    public PropertyGridElement(string name, string value, string category, string description, bool translate = true)
    {
      this.Name = name;
      this.Value = value ?? string.Empty;
      this.Category = category;
      this.Description = description;
      this.Translate = translate;
    }

    ~PropertyGridElement()
    {
      this.Dispose(false);
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object)this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this._disposed)
        return;

      if (disposing)
        Translation.CurrentLanguageChangedEvent -= this.OnLanguageChangedEvent;

      this._disposed = true;
    }

    public void Initialize()
    {
      if (!this._initialized)
      {
        Translation.CurrentLanguageChangedEvent += this.OnLanguageChangedEvent;
        this.TranslateControl();
      }
      this._initialized = true;
    }

    public void Reinitialize()
    {
      if (this._initialized)
      {
        Translation.CurrentLanguageChangedEvent -= this.OnLanguageChangedEvent;
        this._initialized = false;
      }
      this.Initialize();
    }

    public void OnLanguageChangedEvent(object sender, EventArgs e)
    {
      this.TranslateControl();
    }

    private void TranslateControl()
    {
      if (!this.Translate || this.Name?.Length == 0)
        return;

      this.Name = Translation.Instance.Translate("PropertyGridElement", $"{(object)this.Name}-Name", this.Name, new object[0]);
      if (this.Description != string.Empty)
        this.Description = Translation.Instance.Translate("PropertyGridElement", $"{(object)this.Name}-Description", this.Description, new object[0]);
    }
  }
}
