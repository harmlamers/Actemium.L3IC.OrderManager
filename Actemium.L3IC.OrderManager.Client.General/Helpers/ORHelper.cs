using System;
using System.Collections.Generic;
using System.Data;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Business;
using Actemium.L3IC.OrderManager.Model;
using Actemium.Windows.Forms.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.Helpers
{
  public class ORHelper
  {
    private const string CLASSNAME = nameof(ORHelper);
    public static ORHelper Instance = new ORHelper();

    public DataTable GetActualOrdersDataTable(List<Order> orders)
    {
      try
      {
        var dataTable = SuperGrid.DefineGridColumns(
          Translations.OrdersPage.Orders,
          new SuperGrid.ColumnDefinition("Order", "Order", typeof(Order), inUI: false),
          new SuperGrid.ColumnDefinition("Order Id", "Order Id", typeof(int), visible: false),
          new SuperGrid.ColumnDefinition("Code", "Code", typeof(string), visible: true),
          new SuperGrid.ColumnDefinition("Planned Start", "Planned Start", typeof(DateTime)),
          new SuperGrid.ColumnDefinition("Resource", "Resource", typeof(string)),
          new SuperGrid.ColumnDefinition("Article Number", "Article number", typeof(int)),
          new SuperGrid.ColumnDefinition("Article", "Article", typeof(string)),
          new SuperGrid.ColumnDefinition("Quantity", "Quantity", typeof(int)),
          new SuperGrid.ColumnDefinition("Start Time", "Start Time", typeof(string))
          );

        dataTable.BeginLoadData();

        foreach (var order in orders)
        {
          Resource resource = new Resources().GetById(order.ResourceId);
          Material material = new Materials().GetById(order.MaterialId);

          int id = order.Id;
          string code = order.Code;
          DateTime plannedStart = order.PlannedStartDate;
          string resourceDescription = resource.Description;
          int articleNo = material.Code;
          string article = material.Description;
          decimal quantity = order.TargetQuantity;
          DateTime? startTime = order.StartDate;

          var row = dataTable.NewRow();

          dataTable.Rows.Add(
            order,
            id,
            code,
            plannedStart,
            resourceDescription,
            articleNo,
            article,
            quantity,
            startTime
            );

          row.AcceptChanges();
        }

        dataTable.EndLoadData();
        return dataTable;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    public DataTable GetFinishedOrdersDataTable(List<Order> orders)
    {
      try
      {
        var dataTable = SuperGrid.DefineGridColumns(
          Translations.OrdersPage.Orders,
          new SuperGrid.ColumnDefinition("Order", "Order", typeof(Order), inUI: false),
          new SuperGrid.ColumnDefinition("Order Id", "Order Id", typeof(int), visible: false),
          new SuperGrid.ColumnDefinition("Code", "Code", typeof(string), visible: true),
          new SuperGrid.ColumnDefinition("Planned Start", "Planned Start", typeof(DateTime)),
          new SuperGrid.ColumnDefinition("Resource", "Resource", typeof(string)),
          new SuperGrid.ColumnDefinition("Article Number", "Article number", typeof(int)),
          new SuperGrid.ColumnDefinition("Article", "Article", typeof(string)),
          new SuperGrid.ColumnDefinition("Quantity", "Quantity", typeof(int)),
          new SuperGrid.ColumnDefinition("Start Time", "Start Time", typeof(string)),
          new SuperGrid.ColumnDefinition("End Time", "End Time", typeof(string))
          );

        dataTable.BeginLoadData();

        foreach (var order in orders)
        {
          Resource resource = new Resources().GetById(order.ResourceId);
          Material material = new Materials().GetById(order.MaterialId);

          int id = order.Id;
          string code = order.Code;
          DateTime plannedStart = order.PlannedStartDate;
          string resourceDescription = resource.Description;
          int articleNo = material.Code;
          string article = material.Description;
          decimal quantity = order.TargetQuantity;
          DateTime? startTime = order.StartDate;
          DateTime? finishTime = order.FinishDate;

          var row = dataTable.NewRow();

          dataTable.Rows.Add(
            order,
            id,
            code,
            plannedStart,
            resourceDescription,
            articleNo,
            article,
            quantity,
            startTime,
            finishTime
            );

          row.AcceptChanges();
        }

        dataTable.EndLoadData();
        return dataTable;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }
  }
}
