CREATE TABLE [dbo].[BomItems] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [OrderId]    INT             NOT NULL,
    [MaterialId] INT             NOT NULL,
    [Quantity]   DECIMAL (18, 4) NOT NULL,
    [UOM]        NVARCHAR (10)   NOT NULL,
    CONSTRAINT [PK_BomItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BomItems_Materials] FOREIGN KEY ([MaterialId]) REFERENCES [dbo].[Materials] ([Id]),
    CONSTRAINT [FK_BomItems_Orders] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Unit Of Measurement of this BOM item', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BomItems', @level2type = N'COLUMN', @level2name = N'UOM';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'The quantity needed of this BOM item', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BomItems', @level2type = N'COLUMN', @level2name = N'Quantity';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(FK to Materials) The material of this BOM item', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BomItems', @level2type = N'COLUMN', @level2name = N'MaterialId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(FK to Orders) The order this BOM item is related to', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BomItems', @level2type = N'COLUMN', @level2name = N'OrderId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(AutoIdentity) Unique identification of the BOM item', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BomItems', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Items that are on the Bill Of Material', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BomItems';

