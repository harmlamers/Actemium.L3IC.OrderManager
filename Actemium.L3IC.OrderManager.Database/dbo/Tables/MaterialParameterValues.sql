CREATE TABLE [dbo].[MaterialParameterValues] (
    [Id]                  INT           IDENTITY (1, 1) NOT NULL,
    [MaterialId]          INT           NOT NULL,
    [MaterialParameterId] INT           NOT NULL,
    [Value]               NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_MaterialParameterValues] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MaterialParameterValues_MaterialParameters] FOREIGN KEY ([MaterialParameterId]) REFERENCES [dbo].[MaterialParameters] ([Id]),
    CONSTRAINT [FK_MaterialParameterValues_Materials] FOREIGN KEY ([MaterialId]) REFERENCES [dbo].[Materials] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'The actual value of this material specific parameter', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaterialParameterValues', @level2type = N'COLUMN', @level2name = N'Value';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(FK to MaterialParameters) The material parameter of this material parameter value', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaterialParameterValues', @level2type = N'COLUMN', @level2name = N'MaterialParameterId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(FK to Materials) The material this parameter value belongs to', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaterialParameterValues', @level2type = N'COLUMN', @level2name = N'MaterialId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(AutoIdentity) Unique identification of the material parameter value', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaterialParameterValues', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'The value of the material specific parameters', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaterialParameterValues';

