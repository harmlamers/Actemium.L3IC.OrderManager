CREATE TABLE [UM].[Properties] (
    [Id]           INT            NOT NULL,
    [Name]         NVARCHAR (50)  NOT NULL,
    [DefaultValue] NVARCHAR (200) NOT NULL,
    [Type]         INT            NOT NULL,
    [DataType]     INT            NOT NULL,
    CONSTRAINT [PK_Properties] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'0=GeneralSetting, 1=User, 2=Group, 3=Computer', @level0type = N'SCHEMA', @level0name = N'UM', @level1type = N'TABLE', @level1name = N'Properties', @level2type = N'COLUMN', @level2name = N'Type';

