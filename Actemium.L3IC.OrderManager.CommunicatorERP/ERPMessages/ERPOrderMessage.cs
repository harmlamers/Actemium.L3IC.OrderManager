﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.1.854 Microsoft Reciprocal License (Ms-RL)
//    <NameSpace>Actemium.L3IC.OrderManager.CommunicatorERP.ERPMessages</NameSpace>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace Actemium.L3IC.OrderManager.CommunicatorERP.ERPMessages
{

  // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
  /// <remarks/>
  [System.SerializableAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class Message
  {

    private MessageHeader headerField;

    private MessageBody bodyField;

    /// <remarks/>
    public MessageHeader Header
    {
      get
      {
        return this.headerField;
      }
      set
      {
        this.headerField = value;
      }
    }

    /// <remarks/>
    public MessageBody Body
    {
      get
      {
        return this.bodyField;
      }
      set
      {
        this.bodyField = value;
      }
    }
  }

  /// <remarks/>
  [System.SerializableAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  public partial class MessageHeader
  {

    private uint messageIDField;

    private string messageTypeField;

    private System.DateTime messageSentOnField;

    /// <remarks/>
    public uint MessageID
    {
      get
      {
        return this.messageIDField;
      }
      set
      {
        this.messageIDField = value;
      }
    }

    /// <remarks/>
    public string MessageType
    {
      get
      {
        return this.messageTypeField;
      }
      set
      {
        this.messageTypeField = value;
      }
    }

    /// <remarks/>
    public System.DateTime MessageSentOn
    {
      get
      {
        return this.messageSentOnField;
      }
      set
      {
        this.messageSentOnField = value;
      }
    }
  }

  /// <remarks/>
  [System.SerializableAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  public partial class MessageBody
  {

    private MessageBodyOrder orderField;

    /// <remarks/>
    public MessageBodyOrder Order
    {
      get
      {
        return this.orderField;
      }
      set
      {
        this.orderField = value;
      }
    }
  }

  /// <remarks/>
  [System.SerializableAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  public partial class MessageBodyOrder
  {

    private MessageBodyOrderHeader headerField;

    private MessageBodyOrderComponent[] componentsField;

    /// <remarks/>
    public MessageBodyOrderHeader Header
    {
      get
      {
        return this.headerField;
      }
      set
      {
        this.headerField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Component", IsNullable = false)]
    public MessageBodyOrderComponent[] Components
    {
      get
      {
        return this.componentsField;
      }
      set
      {
        this.componentsField = value;
      }
    }
  }

  /// <remarks/>
  [System.SerializableAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  public partial class MessageBodyOrderHeader
  {

    private string processOrderField;

    private uint materialField;

    private string resourceField;

    private decimal targetQuantityField;

    private string targetUnitOfMeasureField;

    private System.DateTime schedStartDateField;

    /// <remarks/>
    public string ProcessOrder
    {
      get
      {
        return this.processOrderField;
      }
      set
      {
        this.processOrderField = value;
      }
    }

    /// <remarks/>
    public uint Material
    {
      get
      {
        return this.materialField;
      }
      set
      {
        this.materialField = value;
      }
    }

    /// <remarks/>
    public string Resource
    {
      get
      {
        return this.resourceField;
      }
      set
      {
        this.resourceField = value;
      }
    }

    /// <remarks/>
    public decimal TargetQuantity
    {
      get
      {
        return this.targetQuantityField;
      }
      set
      {
        this.targetQuantityField = value;
      }
    }

    /// <remarks/>
    public string TargetUnitOfMeasure
    {
      get
      {
        return this.targetUnitOfMeasureField;
      }
      set
      {
        this.targetUnitOfMeasureField = value;
      }
    }

    /// <remarks/>
    public System.DateTime SchedStartDate
    {
      get
      {
        return this.schedStartDateField;
      }
      set
      {
        this.schedStartDateField = value;
      }
    }
  }

  /// <remarks/>
  [System.SerializableAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  public partial class MessageBodyOrderComponent
  {

    private byte bOMItemField;

    private uint bOMMaterialField;

    private decimal bOMQuantityField;

    private string bOMUnitOfMeasureField;

    /// <remarks/>
    public byte BOMItem
    {
      get
      {
        return this.bOMItemField;
      }
      set
      {
        this.bOMItemField = value;
      }
    }

    /// <remarks/>
    public uint BOMMaterial
    {
      get
      {
        return this.bOMMaterialField;
      }
      set
      {
        this.bOMMaterialField = value;
      }
    }

    /// <remarks/>
    public decimal BOMQuantity
    {
      get
      {
        return this.bOMQuantityField;
      }
      set
      {
        this.bOMQuantityField = value;
      }
    }

    /// <remarks/>
    public string BOMUnitOfMeasure
    {
      get
      {
        return this.bOMUnitOfMeasureField;
      }
      set
      {
        this.bOMUnitOfMeasureField = value;
      }
    }
  }


}
