using System;
using System.Collections.Generic;
using System.Data;
using Actemium.ApplicationSettings.Model;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base.PropertyGrids;
using Actemium.L3IC.OrderManager.Client.General.Properties;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.L3IC.OrderManager.General.ExtensionMethods;
using Actemium.UserManagement2;
using Actemium.Windows.Forms.DevComponents2.Controls;
using DevComponents.DotNetBar.SuperGrid;
using Actemium.L3IC.OrderManager.Client.General.ExtensionMethods;
using Actemium.Translations.Business;

namespace Actemium.L3IC.OrderManager.Client.General.Helpers
{
  public class ApplicationSettingsHelper
  {
    private const string CLASSNAME = nameof(ApplicationSettingsHelper);

    public static ApplicationSettingsHelper Instance = new ApplicationSettingsHelper();

    public static string ACICategory = ACICategories.APPLICATIONSETTINGSMANAGEMENT;


    public void PopulateSettingsGrid(List<ApplicationSetting> settingList, Windows.Forms.SuperGrid.SuperGrid grid, GridColumn valueColumn, GridColumn applicationSettingColumn, GridColumn applicationSettingCategoryColumn, GridColumn nameColumn, GridColumn descriptionColumn, GridColumn dataTypeColumn, bool editEnabled)
    {
      try
      {
        //clear the grid
        grid.PrimaryGrid.Rows.Clear();

        editEnabled = editEnabled && CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);
        
        foreach (ApplicationSetting setting in settingList)
        {
          if (!CurrentUser.HasPermission(
            ACICategories.APPLICATIONSETTINGSMANAGEMENT,
            $"{ACIOptions.VIEW}_Category_{((ApplicationSettingsCategories)setting.ApplicationSettingsCategoryId).ToString()}"))
          {
            continue;
          }

          DataTypes datatype = (DataTypes)setting.DataTypeId;

          GridRow gridRow = grid.PrimaryGrid.CreateGridRowFromObject(setting, false);

          gridRow.AllowEdit = editEnabled;
          if (editEnabled && CurrentUser.HasPermission(ACICategory, $"{ACIOptions.MODIFY}_Category_{((ApplicationSettingsCategories)setting.ApplicationSettingsCategoryId).ToString()}"))
          {
            var valueColomn = gridRow[valueColumn];
            valueColomn.EditorType = TypeExtensions.GetType(ApplicationSettings.Business.ApplicationSettings.Instance[nameof(ApplicationSettingsCategories.Actemium), $"DataType_{datatype.ToString()}_Editor"]);
            if(valueColomn.EditorType.Name == "GridListComboBoxExEditControl")
            {
              var dataSourceListItems = new Actemium.ApplicationSettings.Business.DataSourceListItems().GetListById(setting.ListId.GetValueOrDefault(-1));
              valueColomn.EditorParams = new object[] { dataSourceListItems };
            }
          }

          var name = Translations.ApplicationSettings.TranslatedApplicationSettingsNameDictionary[setting.ApplicationSettingId];
          var description = Translations.ApplicationSettings.TranslatedApplicationSettingsDescriptionDictionary[setting.ApplicationSettingId];
          var category = Translations.ApplicationSettings.TranslatedApplicationSettingsCategoryDictionary[setting.ApplicationSettingsCategoryId];

          


          gridRow[applicationSettingColumn].Value = setting;
          gridRow[applicationSettingCategoryColumn].Value = category;
          gridRow[nameColumn].Value = name;
          gridRow[descriptionColumn].Value = description;
          gridRow[dataTypeColumn].Value = datatype;

          
          //tooltips
          gridRow[0].InfoText = setting.Description;
          gridRow[0].InfoImage = Resources.IE_Help_16;

          grid.PrimaryGrid.Rows.Add(gridRow);
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    public DataTable GetDataTable(List<ApplicationSetting> applicationSettings)
    {
      try
      {
        var valueColumn = CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY)
          ? new SuperGrid.ColumnDefinition(
            "Value", "Value", typeof(string), editorType: TypeExtensions.GetType(ApplicationSettings.Business.ApplicationSettings.Instance[nameof(ApplicationSettingsCategories.Actemium), $"DataType_{nameof(DataTypes.String)}_Editor"])) //TODO: Dynamic and better performance
          : new SuperGrid.ColumnDefinition("Value", "Value", typeof(string), editorType: typeof(GridLabelXEditControl));

        var dataTable = SuperGrid.DefineGridColumns(
          Translations.ApplicationSettingsManagementForm.ApplicationSetting,
          new SuperGrid.ColumnDefinition("ApplicationSetting", "ApplicationSetting", typeof(ApplicationSetting), inUI: false),
          new SuperGrid.ColumnDefinition("ApplicationSettingCategory", "ApplicationSettingCategory", typeof(string), editorType: typeof(GridLabelXEditControl)),
          new SuperGrid.ColumnDefinition("Name", "Name", typeof(string), editorType: typeof(GridLabelXEditControl)),
          new SuperGrid.ColumnDefinition("Description", "Description", typeof(string), editorType: typeof(GridLabelXEditControl)),
          new SuperGrid.ColumnDefinition("DataType", "DataType", typeof(string), editorType: typeof(GridLabelXEditControl)),
          valueColumn
          );
        dataTable.BeginLoadData();

        foreach (var item in applicationSettings)
        {
          if(!CurrentUser.HasPermission(
            ACICategories.APPLICATIONSETTINGSMANAGEMENT,
            $"{ACIOptions.VIEW}_Category_{((ApplicationSettingsCategories)item.ApplicationSettingsCategoryId).ToString()}"))
          {
            continue;
          }

          var row = dataTable.NewRow();
          var name = Translations.ApplicationSettings.TranslatedApplicationSettingsNameDictionary[item.ApplicationSettingId];
          var description = Translations.ApplicationSettings.TranslatedApplicationSettingsDescriptionDictionary[item.ApplicationSettingId];
          var category = Translations.ApplicationSettings.TranslatedApplicationSettingsCategoryDictionary[item.ApplicationSettingsCategoryId];
          DataTypes datatype = (DataTypes)item.DataTypeId;

          dataTable.Rows.Add(
            item,
            category,
            name,
           description,
           datatype,
           item.Value
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

    public List<PropertyGridElement> CreatePropertyGridElements(ApplicationSetting item)
    {
      var result = new List<PropertyGridElement>();
      try
      {
        if (item != null)
        {
          var category = string.Format(Translations.ApplicationSettingsManagementForm.ApplicationSetting, item.Name);

          result.Add(new PropertyGridElement("ApplicationSettingId", item.ApplicationSettingId.ToString(), category, ""));
          result.Add(new PropertyGridElement("ApplicationSettingsCategory", Translations.ApplicationSettings.TranslatedApplicationSettingsCategoryDictionary[item.ApplicationSettingsCategoryId], category, ""));
          result.Add(new PropertyGridElement("Name", Translations.ApplicationSettings.TranslatedApplicationSettingsNameDictionary[item.ApplicationSettingId], category, ""));
          result.Add(new PropertyGridElement("Description", Translations.ApplicationSettings.TranslatedApplicationSettingsDescriptionDictionary[item.ApplicationSettingId], category, ""));
          result.Add(new PropertyGridElement("DataType", ((DataTypes)item.DataTypeId).ToString(), category, ""));
          result.Add(new PropertyGridElement("Value", item.Value, category, ""));
        }

        return result;
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
        result.Add(PropertyGridElement.NoData);
        return result;
      }
    }
  }
}
