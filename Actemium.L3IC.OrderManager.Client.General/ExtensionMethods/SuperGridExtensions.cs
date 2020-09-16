using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using Actemium.Diagnostics;
using DevComponents.DotNetBar.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.ExtensionMethods
{
  public static class SuperGridExtensions
  {
    private const string CLASSNAME = nameof(SuperGridExtensions);

    public static GridRow CreateGridRowFromObject<T>(this GridPanel gridPanel, T obj, bool bDirty = false) where T : class
    {
      if (gridPanel == null || obj == null)
        return null;

      var props = TypeDescriptor.GetProperties(typeof(T));

      var values = new object[gridPanel.Columns.Count];

      for (int j = 0; j < values.Length; j++)
      {
        values[j] = null;
        for (int i = 0; i < props.Count; i++)
        {
          PropertyDescriptor prop = props[i];
          if (prop.Name == gridPanel.Columns[j].DataPropertyName)
          {
            values[j] = props[i].GetValue(obj);
            break;
          }
        }
      }

      return new GridRow(values) { Tag = obj, RowDirty = bDirty };
    }

    public static GridRow CreateGridRowFromValues<T>(this GridPanel gridPanel, T rowTag, params object[] values) where T : class
    {
      if (gridPanel == null || values == null)
        return null;

      return new GridRow(values) { Tag = rowTag };
    }

    public static void RefreshGridRowFromObject<T>(this GridRow gridRow, T obj) where T : class
    {
      if (gridRow == null || obj == null || gridRow.GridPanel == null)
        return;

      GridPanel gridPanel = gridRow.GridPanel;
      var props = TypeDescriptor.GetProperties(typeof(T));

      for (int j = 0; j < gridPanel.Columns.Count; j++)
      {
        for (int i = 0; i < props.Count; i++)
        {
          PropertyDescriptor prop = props[i];
          if (prop.Name == gridPanel.Columns[j].DataPropertyName)
          {
            gridRow[gridPanel.Columns[j]].Value = props[i].GetValue(obj);
            break;
          }
        }
      }

      gridRow.Tag = obj;
    }

    public static void SelectRow(this GridPanel gridPanel, GridRow gridRow, bool ensureVisible = true)
    {
      if (gridPanel == null || gridRow == null)
        return;

      try
      {
        gridPanel.ClearSelectedCells();
        gridPanel.ClearSelectedRows();

        gridPanel.SetActiveRow(gridRow);
        gridPanel.Select(gridRow);

        if (ensureVisible && !gridRow.IsOnScreen)
        {
          gridRow.EnsureVisible();
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError(string.Empty, Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    public static void SelectFirstRow(this GridPanel gridPanel)
    {
      if (gridPanel?.Rows == null)
        return;

      try
      {
        IEnumerable<GridRow> gridRows = gridPanel.Rows.OfType<GridRow>().ToList();
        if (gridRows.Any())
          gridPanel.SelectRow(gridRows.First());
      }
      catch (Exception ex)
      {
        Trace.WriteError(string.Empty, Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    public static void SelectObject(this GridPanel gridPanel, object objectToSelect, bool selectFirstRowWhenNoMatch = true, string dataRowViewIndexColumnName = "Id")
    {
      if (gridPanel?.Rows == null)
        return;

      try
      {
        IEnumerable<GridRow> gridRows = gridPanel.Rows.OfType<GridRow>().ToList();
        GridRow foundRow = null;
        if (objectToSelect != null && gridRows.Any())
          foundRow = FindRow(gridRows, objectToSelect, dataRowViewIndexColumnName);

        if (foundRow != null)
          gridPanel.SelectRow(foundRow);
        else if (selectFirstRowWhenNoMatch && gridRows.Any())
          gridPanel.SelectRow(gridRows.First());
      }
      catch (Exception ex)
      {
        Trace.WriteError("{0}", Trace.GetMethodName(), CLASSNAME, ex, objectToSelect);
      }
    }

    private static GridRow FindRow(IEnumerable<GridRow> gridRows, object objectToSelect, string dataRowViewIndexColumnName)
    {
      GridRow foundRow = null;
      foreach (GridRow gridRow in gridRows)
      {
        if (gridRow.Tag?.Equals(objectToSelect) == true)
        {
          foundRow = gridRow;
          break;
        }

        if (gridRow.DataItem != null)
        {
          if (gridRow.DataItem.Equals(objectToSelect))
          {
            foundRow = gridRow;
            break;
          }

          if (gridRow.DataItem is DataRowView dataRowView)
          {
            if (objectToSelect.Equals(dataRowView.Row[dataRowViewIndexColumnName]))
            {
              foundRow = gridRow;
              break;
            }
          }
        }

        // recursive call to row's children
        if (gridRow.Rows?.Any() == true)
        {
          foundRow = FindRow(gridRow.Rows.OfType<GridRow>(), objectToSelect, dataRowViewIndexColumnName);
          if (foundRow != null)
            break;
        }
      }

      return foundRow;
    }
  }
}
