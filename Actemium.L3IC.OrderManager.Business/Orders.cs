using System;
using System.Collections.Generic;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Business.Enums;
using Actemium.L3IC.OrderManager.Model;

namespace Actemium.L3IC.OrderManager.Business
{
  public partial class Orders : OrdersGennie
  {
    public List<Model.Order> GetAllActual()
    {
      try
      {
        DataAccess.Orders orders = new DataAccess.Orders();
        List<Model.Order> result = orders.GetAllActual();
        
        return ChangeTimes(result);
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    public List<Model.Order> GetAllHistory()
    {
      try
      {
        DataAccess.Orders orders = new DataAccess.Orders();
        List<Model.Order> result = orders.GetAllHistory();

        return ChangeTimes(result);
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    public List<Model.Order> GetByCode(string code)
    {
      try
      {
        DataAccess.Orders orders = new DataAccess.Orders();
        List<Model.Order> result = orders.GetByCode(code);

        return result;
      }
      catch (Exception ex)
      {
        Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, code);
        throw;
      }
    }

    public OrderStatus StartOrder(Order orderToStart)
    {
      DataAccess.Orders orders = new DataAccess.Orders();
      List<Model.Order> actualOrdersResult = orders.GetAllActual();

      foreach (Model.Order actualOrder in actualOrdersResult)
      {
        if (actualOrder.StartDate != null && actualOrder.ResourceId == orderToStart.ResourceId)
        {
          return OrderStatus.Resource_in_use;
        }
      }

      orderToStart.StartDate = DateTime.UtcNow;
      orders.Modify(orderToStart);

      return OrderStatus.Succes;
    }

    public OrderStatus StopOrder(Order order)
    {
      DataAccess.Orders stopOrder = new DataAccess.Orders();

      if (order.StartDate is null)
      {
        return OrderStatus.Stop_Before_Start;
      }
      
      order.FinishDate = DateTime.UtcNow;
      order.StartDate = order.StartDate.Value.ToUniversalTime();
      stopOrder.Modify(order);

      return OrderStatus.Succes;
    }

    private List<Model.Order> ChangeTimes(List<Model.Order> orders)
    {
      foreach (Model.Order order in orders)
      {
        order.PlannedStartDate = order.PlannedStartDate.ToLocalTime();
        order.StartDate = UniversalToLocalDateTime(order.StartDate);
        order.FinishDate = UniversalToLocalDateTime(order.FinishDate);
      }

      return orders;
    }

    private DateTime? UniversalToLocalDateTime(DateTime? universalDateTime)
    {
      if (universalDateTime is null)
      {
        return null;
      }
      else
      {
        DateTime localTime = universalDateTime.Value;

        return localTime.ToLocalTime();
      }
    }
  }
}
