using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.Translations.Objects;
using Actemium.UserManagement2;
using Actemium.Windows.Forms.DevComponents2.Controls;
using DevComponents.DotNetBar.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.Helpers
{
  public class ApplicationTranslationsHelper
  {
    private const string CLASSNAME = nameof(ApplicationTranslationsHelper);

    public static ApplicationTranslationsHelper Instance = new ApplicationTranslationsHelper();

    public DataTable GetDataTable(List<ApplicationTranslation> applicationTranslations)
    {
      try
      {
        var languages = GlobalHandler.ActiveLanguages();

        var columns = new List<SuperGrid.ColumnDefinition>
                      {
                        new SuperGrid.ColumnDefinition(
                          "ApplicationTranslation", "ApplicationTranslation",
                          typeof(ApplicationTranslation), inUI: false),
                        new SuperGrid.ColumnDefinition(
                          "Key", "Form / Key", typeof(string),
                          editorType: typeof(GridLabelXEditControl)),
                        new SuperGrid.ColumnDefinition(
                          "SubKey", "Control / SubKey", typeof(string),
                          editorType: typeof(GridLabelXEditControl))
                      };
        foreach (var language in languages)
        {
          var valueColumn = CurrentUser.HasPermission(ACICategories.TRANSLATIONS, ACIOptions.MODIFY)
            ? new SuperGrid.ColumnDefinition(
              $"Value_{language.Id.ToString()}", language.Name, typeof(string), editorType: typeof(GridTextBoxXEditControl))
            : new SuperGrid.ColumnDefinition($"Value_{language.Id.ToString()}", language.Name, typeof(string), editorType: typeof(GridLabelXEditControl));
          columns.Add(valueColumn);
        }
        
        var dataTable = SuperGrid.DefineGridColumns(
          Translations.TranslationsForm.TranslationText,
          columns.ToArray()
          );
        dataTable.BeginLoadData();

        var english = applicationTranslations.Where(x => x.LanguageId == (int)Enums.Languages.en_GB).ToList();

        foreach (var applicationTranslation in english)
        {
          var row = dataTable.NewRow();
          var key = applicationTranslation.Key;
          var subKey = applicationTranslation.SubKey;

          var items = new List<object> {applicationTranslation, key, subKey};
          foreach (var language in languages)
          {
            items.Add(applicationTranslations.Find(x=>x.Key.Equals(key) && x.SubKey.Equals(subKey) && x.LanguageId == language.Id)?.Value ?? string.Empty);
          }

          dataTable.Rows.Add(
            items.ToArray()
          );

          row.AcceptChanges();

        }

        dataTable.EndLoadData();
        return dataTable;
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }
  }
}
