CREATE TABLE [dbo].[Materials] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [MaterialGroupId] INT           NOT NULL,
    [Code]            INT           NOT NULL,
    [Description]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Materials_MaterialGroups] FOREIGN KEY ([MaterialGroupId]) REFERENCES [dbo].[MaterialGroups] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Materials]
    ON [dbo].[Materials]([Code] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Description of this material', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Materials', @level2type = N'COLUMN', @level2name = N'Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Unique key of this material', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Materials', @level2type = N'COLUMN', @level2name = N'Code';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(FK to MaterialGroups) The material group this material belongs to', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Materials', @level2type = N'COLUMN', @level2name = N'MaterialGroupId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(AutoIdentity) Unique identification of the material', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Materials', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'The raw and finished goods materials for the production', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Materials';

