CREATE TABLE [AS].[ApplicationSettingsCategories] (
    [ApplicationSettingsCategoryId] INT            NOT NULL,
    [Name]                          NVARCHAR (100) NOT NULL,
    [Description]                   NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_ApplicationSettingsCategories] PRIMARY KEY CLUSTERED ([ApplicationSettingsCategoryId] ASC),
    CONSTRAINT [uq_Category] UNIQUE NONCLUSTERED ([Name] ASC)
);



