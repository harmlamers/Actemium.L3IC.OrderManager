CREATE TABLE [dbo].[Orders] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [OrderMessageId]   INT             NOT NULL,
    [Code]             NVARCHAR (50)   NOT NULL,
    [MaterialId]       INT             NOT NULL,
    [ResourceId]       INT             NOT NULL,
    [TargetQuantity]   DECIMAL (18, 4) NOT NULL,
    [UOM]              NVARCHAR (10)   NOT NULL,
    [PlannedStartDate] DATETIME2 (7)   NOT NULL,
    [StartDate]        DATETIME2 (7)   NULL,
    [FinishDate]       DATETIME2 (7)   NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Orders_Materials] FOREIGN KEY ([MaterialId]) REFERENCES [dbo].[Materials] ([Id]),
    CONSTRAINT [FK_Orders_OrderMessages] FOREIGN KEY ([OrderMessageId]) REFERENCES [dbo].[OrderMessages] ([Id]),
    CONSTRAINT [FK_Orders_Resources] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[Resources] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'The actual date and time the production of this order ended', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Orders', @level2type = N'COLUMN', @level2name = N'FinishDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'The actual date and time the production of this order started', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Orders', @level2type = N'COLUMN', @level2name = N'StartDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'The desired date and time to start production of this order ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Orders', @level2type = N'COLUMN', @level2name = N'PlannedStartDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'The Unit Of Measurement belonging to the target quantity of this order', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Orders', @level2type = N'COLUMN', @level2name = N'UOM';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'The desired quantity to produce for this order', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Orders', @level2type = N'COLUMN', @level2name = N'TargetQuantity';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(FK to Resources) The resource this order must be produced on', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Orders', @level2type = N'COLUMN', @level2name = N'ResourceId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(FK to Materials) The finished goods material of this order', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Orders', @level2type = N'COLUMN', @level2name = N'MaterialId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Unique process order code key of this order', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Orders', @level2type = N'COLUMN', @level2name = N'Code';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(FK to Orders) The order message (Header) of this order', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Orders', @level2type = N'COLUMN', @level2name = N'OrderMessageId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(AutoIdentity) Unique identification of the order', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Orders', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'All production orders', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Orders';

