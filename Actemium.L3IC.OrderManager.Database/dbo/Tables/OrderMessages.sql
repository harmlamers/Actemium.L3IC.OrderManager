CREATE TABLE [dbo].[OrderMessages] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Code]         NVARCHAR (50) NOT NULL,
    [SentDate]     DATETIME2 (7) NOT NULL,
    [ReceivedDate] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Date and time the order message has been inserted into the MES system', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderMessages', @level2type = N'COLUMN', @level2name = N'ReceivedDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Date and time the order message has been sent to MES', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderMessages', @level2type = N'COLUMN', @level2name = N'SentDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Unique key of this order message', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderMessages', @level2type = N'COLUMN', @level2name = N'Code';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(AutoIdentity) Unique identification of the order message', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderMessages', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Logging of all messages that have been received for orders from an external system', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderMessages';

