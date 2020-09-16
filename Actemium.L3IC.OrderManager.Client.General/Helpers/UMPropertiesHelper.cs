using System;
using System.Collections.Generic;
using System.Data;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.UserManagement2;
using Actemium.UserManagement2.Model;
using Actemium.Windows.Forms.DevComponents2.Controls;
using DevComponents.DotNetBar.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.Helpers
{
  public class UMPropertiesHelper
  {
    private const string CLASSNAME = nameof(UMPropertiesHelper);

    public static UMPropertiesHelper Instance = new UMPropertiesHelper();

    public DataTable GetDataTable(List<ViewUserPropertyValue> viewUserPropertyValues, string aciCategory)
    {
      try
      {
        var valueColumn = CurrentUser.HasPermission(aciCategory, ACIOptions.MODIFY)
          ? new SuperGrid.ColumnDefinition(
            "Value", "Value", typeof(string), editorType: typeof(GridTextBoxXEditControl))
          : new SuperGrid.ColumnDefinition("Value", "Value", typeof(string), editorType: typeof(GridLabelXEditControl));
        var defaultValueColumn = new SuperGrid.ColumnDefinition("DefaultValue", "Default value", typeof(string), editorType: typeof(GridLabelXEditControl));
        var dataTable = SuperGrid.DefineGridColumns(
          Translations.PropertiesPopupForm.Property,
          new SuperGrid.ColumnDefinition("PropertyValue", "PropertyValue", typeof(ViewUserPropertyValue), inUI: false),
          new SuperGrid.ColumnDefinition("Name", "Name", typeof(string), editorType: typeof(GridLabelXEditControl)),
          new SuperGrid.ColumnDefinition("DataType", "DataType", typeof(string), editorType: typeof(GridLabelXEditControl)),
          defaultValueColumn,
          valueColumn
          );
        dataTable.BeginLoadData();

        foreach (var item in viewUserPropertyValues)
        {
          var row = dataTable.NewRow();
          var name = Translations.Enums.TranslatedEnumDictionary[(UserManagementProperties)item.PropertyId];
          DataTypes datatype = (DataTypes)item.DataType;

          dataTable.Rows.Add(
            item,
            name,
            datatype,
           item.DefaultValue,
           item.Value ?? String.Empty
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

    public DataTable GetDataTable(List<ViewComputerPropertyValue> viewComputerPropertyValues, string aciCategory)
    {
      try
      {
        var valueColumn = CurrentUser.HasPermission(aciCategory, ACIOptions.MODIFY)
          ? new SuperGrid.ColumnDefinition(
            "Value", "Value", typeof(string), editorType: typeof(GridTextBoxXEditControl))
          : new SuperGrid.ColumnDefinition("Value", "Value", typeof(string), editorType: typeof(GridLabelXEditControl));
        var defaultValueColumn = new SuperGrid.ColumnDefinition("DefaultValue", "Default value", typeof(string), editorType: typeof(GridLabelXEditControl));
        var dataTable = SuperGrid.DefineGridColumns(
          Translations.PropertiesPopupForm.Property,
          new SuperGrid.ColumnDefinition("PropertyValue", "PropertyValue", typeof(ViewComputerPropertyValue), inUI: false),
          new SuperGrid.ColumnDefinition("Name", "Name", typeof(string), editorType: typeof(GridLabelXEditControl)),
          new SuperGrid.ColumnDefinition("DataType", "DataType", typeof(string), editorType: typeof(GridLabelXEditControl)),
          defaultValueColumn,
          valueColumn
          );
        dataTable.BeginLoadData();

        foreach (var item in viewComputerPropertyValues)
        {
          var row = dataTable.NewRow();
          var name = Translations.Enums.TranslatedEnumDictionary[(UserManagementProperties)item.PropertyId];
          DataTypes datatype = (DataTypes)item.DataType;

          dataTable.Rows.Add(
            item,
            name,
            datatype,
           item.DefaultValue,
           item.Value ?? String.Empty
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

    public DataTable GetDataTable(List<ViewGroupPropertyValue> viewGroupPropertyValues, string aciCategory)
    {
      try
      {
        var valueColumn = CurrentUser.HasPermission(aciCategory, ACIOptions.MODIFY)
          ? new SuperGrid.ColumnDefinition(
            "Value", "Value", typeof(string), editorType: typeof(GridTextBoxXEditControl))
          : new SuperGrid.ColumnDefinition("Value", "Value", typeof(string), editorType: typeof(GridLabelXEditControl));
        var defaultValueColumn = new SuperGrid.ColumnDefinition("DefaultValue", "Default value", typeof(string), editorType: typeof(GridLabelXEditControl));
        var dataTable = SuperGrid.DefineGridColumns(
          Translations.PropertiesPopupForm.Property,
          new SuperGrid.ColumnDefinition("PropertyValue", "PropertyValue", typeof(ViewGroupPropertyValue), inUI: false),
          new SuperGrid.ColumnDefinition("Name", "Name", typeof(string), editorType: typeof(GridLabelXEditControl)),
          new SuperGrid.ColumnDefinition("DataType", "DataType", typeof(string), editorType: typeof(GridLabelXEditControl)),
          defaultValueColumn,
          valueColumn
          );
        dataTable.BeginLoadData();

        foreach (var item in viewGroupPropertyValues)
        {
          var row = dataTable.NewRow();
          var name = Translations.Enums.TranslatedEnumDictionary[(UserManagementProperties)item.PropertyId];
          DataTypes datatype = (DataTypes)item.DataType;

          dataTable.Rows.Add(
            item,
            name,
            datatype,
           item.DefaultValue,
           item.Value ?? String.Empty
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
