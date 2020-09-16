using System;
using System.Collections.Generic;
using System.Data;
using Actemium.L3IC.OrderManager.Client.General.UserControls.GridEditControls;
using Actemium.Windows.Forms.DevComponents2.Controls;
using DevComponents.DotNetBar.SuperGrid;
using Actemium.History.Model;
using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General.Helpers
{
  public class HistoryHelper
  {
    private const string CLASSNAME = nameof(HistoryHelper);

    public static HistoryHelper Instance = new HistoryHelper();

    public DataTable GetDataTable(List<HistoryKey> historyKeys)
    {
      try
      {
        var dataTable = SuperGrid.DefineGridColumns(
          Translations.HistoryKeyManagementForm.HistoryKey,
          new SuperGrid.ColumnDefinition("HistoryKey", "HistoryKey", typeof(HistoryKey), inUI: false),
          new SuperGrid.ColumnDefinition("Key", "History Key", typeof(string), editorType: typeof(GridLabelXEditControl)),
          new SuperGrid.ColumnDefinition("ShowInClient", "Show in client", typeof(bool), editorType: typeof(GridCheckBoxXEditControl)),
          new SuperGrid.ColumnDefinition("SaveInDatabase", "Save in database", typeof(bool), editorType: typeof(GridCheckBoxXEditControl)),
          new SuperGrid.ColumnDefinition("TraceLevel", "Trace Level", typeof(int), editorType: typeof(GridSourceLevelsComboBoxExEditControl))
          );
        dataTable.BeginLoadData();

        foreach (var item in historyKeys)
        {
          var row = dataTable.NewRow();

          dataTable.Rows.Add(
            item,
            item.HistoryKey,
            item.ShowInClient,
            item.SaveInDatabase,
            item.TraceLevelValue
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

    //public DataTable GetDataTable(List<ViewComputerPropertyValue> viewComputerPropertyValues, string aciCategory)
    //{
    //  try
    //  {
    //    var valueColumn = CurrentUser.HasPermission(aciCategory, ACIOptions.Modify)
    //      ? new SuperGrid.ColumnDefinition(
    //        "Value", "Value", typeof(string), editorType: typeof(GridTextBoxXEditControl))
    //      : new SuperGrid.ColumnDefinition("Value", "Value", typeof(string), editorType: typeof(GridLabelXEditControl));
    //    var defaultValueColumn = new SuperGrid.ColumnDefinition("DefaultValue", "Default value", typeof(string), editorType: typeof(GridLabelXEditControl));
    //    var dataTable = SuperGrid.DefineGridColumns(
    //      Translations.PropertiesPopupForm.Property,
    //      new SuperGrid.ColumnDefinition("PropertyValue", "PropertyValue", typeof(ViewComputerPropertyValue), inUI: false),
    //      new SuperGrid.ColumnDefinition("Name", "Name", typeof(string), editorType: typeof(GridLabelXEditControl)),
    //      new SuperGrid.ColumnDefinition("DataType", "DataType", typeof(string), editorType: typeof(GridLabelXEditControl)),
    //      defaultValueColumn,
    //      valueColumn
    //      );
    //    dataTable.BeginLoadData();

    //    foreach (var item in viewComputerPropertyValues)
    //    {
    //      var row = dataTable.NewRow();
    //      var name = Translations.Enums.TranslatedEnumDictionary[(UserManagementProperties)item.PropertyId];
    //      DataTypes datatype = (DataTypes)item.DataType;

    //      dataTable.Rows.Add(
    //        item,
    //        name,
    //        datatype,
    //       item.DefaultValue,
    //       item.Value ?? String.Empty
    //        );

    //      row.AcceptChanges();
    //    }

    //    dataTable.EndLoadData();
    //    return dataTable;
    //  }
    //  catch (Exception ex)
    //  {
    //    Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
    //    throw;
    //  }
    //}
  }
}
