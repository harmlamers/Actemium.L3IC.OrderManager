CREATE TABLE [dbo].[MaterialParameters] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Code]            NVARCHAR (50) NOT NULL,
    [MaterialGroupId] INT           NOT NULL,
    CONSTRAINT [PK_MaterialParameters] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MaterialParameters_MaterialGroups] FOREIGN KEY ([MaterialGroupId]) REFERENCES [dbo].[MaterialGroups] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_MaterialParameters]
    ON [dbo].[MaterialParameters]([Code] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(FK to MaterialGroups) MaterialParameters are material group specific. The material group this material parameter belongs to', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaterialParameters', @level2type = N'COLUMN', @level2name = N'MaterialGroupId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Unique key of this material parameter', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaterialParameters', @level2type = N'COLUMN', @level2name = N'Code';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(AutoIdentity) Unique identification of the material parameter', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaterialParameters', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Material specific parameters', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaterialParameters';

