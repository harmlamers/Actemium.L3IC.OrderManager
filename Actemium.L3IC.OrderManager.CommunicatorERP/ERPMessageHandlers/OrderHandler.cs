using System;
using System.Collections.Generic;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Business;
using Actemium.L3IC.OrderManager.CommunicatorERP.ERPMessages;
using Actemium.L3IC.OrderManager.Model;
using Actemium.Transactions;

namespace Actemium.L3IC.OrderManager.CommunicatorERP.ERPMessageHandlers
{
  class OrderHandler : BaseHandler
  {
    private const string CLASSNAME = nameof(OrderHandler);

    public Message OrderMessage { get; set; }

    public bool HandleMessage()
    {
      Order newOrder = CreateNewOrder(OrderMessage);
      OrderMessage newOrderMessage = CreateNewOrderMessage(OrderMessage);
      List<BomItem> newBomItems = CreateNewBomItems(OrderMessage);

      if (newOrder != null && newBomItems.Count > 0)
      {
        if (CreateOrModifyOrderInDatabase(newOrder, newOrderMessage, newBomItems))
        {
          return false;
        }
      }

      return true;
    }

    private Order CreateNewOrder(Message orderMessage)
    {
      Order createdOrder;
      // MHL : Vraag: Gaat het deserializen van een ordermessage mis als ik bijvoorbeeld geen orderheader op geef? Als dat zo is moet je hier eigenlijk wel controlen op Null
      // anders krijg je hele lelijke NullRefExceptions
      string orderMessageCode = CheckMessageCode(orderMessage.Body.Order.Header.ProcessOrder);
      int materialId = CheckAndFormatMaterial(orderMessage.Body.Order.Header.Material);
      int resourceId = CheckAndFormatResourceId(orderMessage.Body.Order.Header.Resource);
      decimal quantity = CheckQuantity(orderMessage.Body.Order.Header.TargetQuantity);
      string uom = CheckUom(orderMessage.Body.Order.Header.TargetUnitOfMeasure);

      if (orderMessageCode != HAS_ERROR_STRING && materialId != HAS_ERROR_INT && resourceId != HAS_ERROR_INT && quantity != HAS_ERROR_INT && uom != HAS_ERROR_STRING)
      {
        createdOrder = new Order()
        {
          Code = orderMessageCode,
          MaterialId = materialId,
          ResourceId = resourceId,
          TargetQuantity = quantity,
          UOM = uom,
          PlannedStartDate = orderMessage.Body.Order.Header.SchedStartDate,
          StartDate = null,
          FinishDate = null,
        };

        // MHL : je zou bovenstaande ook anders kunnen schrijven, beide goed maar onderstaande vind ik in ieder geval wel duidelijker.
        // Minder typen bovendien en bijkomend voordeel is dat als het ergens halvewege fout gaat het object niet aangemaakt wordt en je dus niet met
        // halve bak blijft zitten
        //  createdOrder = new Order()
        //  {
        //    Code = orderMessageCode,
        //    MaterialId = materialId,
        //    ResourceId = resourceId,
        //    TargetQuantity = quantity,
        //    UOM = uom,
        //    PlannedStartDate = orderMessage.Body.Order.Header.SchedStartDate,
        //    StartDate = null,
        //    FinishDate = null,
        //};
      }
      else
      {
        return null;
      }

      return createdOrder;
    }

    private OrderMessage CreateNewOrderMessage(Message orderMessage)
    {
      OrderMessage newOrderMessage = new OrderMessage
      {
        Code = FormatMessageCode(orderMessage.Header.MessageID),
        SentDate = orderMessage.Header.MessageSentOn,
        ReceivedDate = DateTime.UtcNow
      };

      return newOrderMessage;
    }

    private List<BomItem> CreateNewBomItems(Message orderMessage)
    {
      List<BomItem> createdBomItems = new List<BomItem>();

      foreach (var bomItem in orderMessage.Body.Order.Components)
      {
        BomItem createdBomItem = new BomItem();

        int materialId = CheckAndFormatMaterial(bomItem.BOMMaterial);
        string uom = CheckUom(bomItem.BOMUnitOfMeasure);

        if (materialId != HAS_ERROR_INT && uom != HAS_ERROR_STRING)
        {
          createdBomItem.MaterialId = materialId;
          createdBomItem.Quantity = bomItem.BOMQuantity;
          createdBomItem.UOM = bomItem.BOMUnitOfMeasure;
        }
        else
        {
          return null;
        }

        createdBomItems.Add(createdBomItem);
      }

      return createdBomItems;
    }

    // MHL : deze functie heeft een verwarrende naam, hij doet namelijk iets met messageId, niet met MessageCode. Op zich niet erg maar het veld MessageCode bestaat ook
    private string FormatMessageCode(uint messageId)
    {
      string messageIdString = messageId.ToString();
      return messageIdString;
    }

    private string CheckMessageCode(string messageCode)
    {
      if (messageCode.StartsWith("O_"))
      {
        return messageCode;
      }
      else
      {
        Trace.WriteError($"Ordermessage Code {messageCode} is not in the right format", Trace.GetMethodName(), CLASSNAME);
        Console.WriteLine($"Ordermessage Code {messageCode} is not in the right format");
      }

      return HAS_ERROR_STRING;
    }

    // MHL : er kwam een unit in en er komt een int uit, is dat met opzet? Misschien vanwege de error int? Je kunt zou namelijk wel veel getallen kwijtraken
    private int CheckAndFormatMaterial(uint materialCode)
    {
      // MHL : de lengte check is hier niet zo zinvol, de input parameter is UInt32 en die heeft een max waarde van 4294967295, dat is maar 10 lang

      string materialCodeString = materialCode.ToString();
      if (int.TryParse(materialCodeString, out int materialId))
      {
        List<Material> materials = new Materials().GetByCode(materialId);
        if (materials.Count > 0)
        {
          return materials[0].Id;
        }
        else
        {
          Trace.WriteError($"Material with code {materialCodeString} does not exist", Trace.GetMethodName(), CLASSNAME);
        }
      }
      else
      {
        Trace.WriteError($"Material with code {materialCodeString} is not in de right format", Trace.GetMethodName(), CLASSNAME);
      }

      return HAS_ERROR_INT;
    }

    private int CheckAndFormatResourceId(string resourceCode)
    {
      const int RESOURCE_MAX_LENGTH = 50;

      if (resourceCode.Length <= RESOURCE_MAX_LENGTH)
      {
        List<Resource> resources = new Resources().GetByCode(resourceCode);
        if (resources.Count > 0)
        {
          return resources[0].Id;
        }
        else
        {
          Trace.WriteError($"Resource {resourceCode} is not a resource", Trace.GetMethodName(), CLASSNAME);
        }
      }
      else
      {
        Trace.WriteError($"Resource {resourceCode} is not in the right format", Trace.GetMethodName(), CLASSNAME);
      }

      return HAS_ERROR_INT;
    }

    private decimal CheckQuantity(decimal quantity)
    {
      const int TARGETQUANT_MAX_LENGTH = 10;

      string quantityString = quantity.ToString();

      if (quantityString.Length <= TARGETQUANT_MAX_LENGTH)
      {
        return quantity;
      }
      else
      {
        Trace.WriteError($"Target quantity {quantityString} is not in the right format", Trace.GetMethodName(), CLASSNAME);
      }

      return HAS_ERROR_INT;
    }

    private string CheckUom(string uom)
    {
      const int ORDER_MESSAGE_UOM_MAX_LENGTH = 10;

      if (uom.Length <= ORDER_MESSAGE_UOM_MAX_LENGTH)
      {
        return uom;
      }
      else
      {
        Trace.WriteError($"Unit of measure (UOM) {uom} is not in the right format", Trace.GetMethodName(), CLASSNAME);
      }

      return HAS_ERROR_STRING;
    }

    // MHL : Let op, als er ergens in deze functie iets mis gaat staat er een halve order in de database, zorg dat alle acties om een order aan te maken binnen een transactie vallen
    // gebruik hiervoor de transactionscope uit het package Actemium.Data (nuGet)
    private bool CreateOrModifyOrderInDatabase(Order order, OrderMessage orderMessage, List<BomItem> bomItems)
    {
      List<Order> existingOrders = new Orders().GetByCode(order.Code);
      TransactionScope transaction = new TransactionScope();

      if (existingOrders.Count > 0)
      {
        OrderMessage existingOrderMessage = new OrderMessages().GetById(existingOrders[0].OrderMessageId);

        if (DateTime.Compare(existingOrderMessage.SentDate, orderMessage.SentDate) < 0)
        {
          if (existingOrders[0].StartDate is null)
          {
            using (transaction)
            {
              order.Id = existingOrders[0].Id;
              order.OrderMessageId = new OrderMessages().Add(orderMessage);
              List<BomItem> existingBomItems = new BomItems().GetByOrderId(order.Id);

              SetOrderIdToBomItems(bomItems, order.Id);
              DeleteExistingBomItems(existingBomItems);
              AddBomItems(bomItems);

              new Orders().Modify(order);

              transaction.Complete();

              return true;
            }           
          }
          else
          {
            Trace.WriteError($"Order with code {order.Code} is already exists and started", Trace.GetMethodName(), CLASSNAME);
          }
        }
        else
        {
          // MHL : newer senddate?
          Trace.WriteError($"Order with code {order.Code} is already exists and has an newer senddate", Trace.GetMethodName(), CLASSNAME);
        }
      }
      else
      {
        // MHL : voor ieder business class is een singleton gemaakt die je kunt gebruiken bijv: OrderMessages.Instance Dat scheelt de hele tijd classes initialiseren
        // dit geldt ook al zo in de GUI maar toen is het me niet opgevallen. Onderstaande is overigens ook niet fout.
        using (transaction)
        {
          order.OrderMessageId = new OrderMessages().Add(orderMessage);
          order.Id = new Orders().Add(order);

          SetOrderIdToBomItems(bomItems, order.Id);
          AddBomItems(bomItems);

          transaction.Complete();
          return true;
        }
      }

      return false;
    }

    private void SetOrderIdToBomItems(List<BomItem> bomItems, int orderId)
    {
      foreach (BomItem bomItem in bomItems)
      {
        bomItem.OrderId = orderId;
      }
    }

    private void DeleteExistingBomItems(List<BomItem> bomItems)
    {
      foreach (BomItem bomItem in bomItems)
      {
        new BomItems().Delete(bomItem);
      }
    }

    private void AddBomItems(List<BomItem> bomItems)
    {
      foreach (BomItem bomItem in bomItems)
      {

        new BomItems().Add(bomItem);
      }
    }
  }
}
