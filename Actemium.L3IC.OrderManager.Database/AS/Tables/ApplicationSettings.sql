CREATE TABLE [AS].[ApplicationSettings] (
    [ApplicationSettingId]          INT            NOT NULL,
    [ApplicationSettingsCategoryId] INT            NOT NULL,
    [Name]                          NVARCHAR (100) NOT NULL,
    [Description]                   NVARCHAR (100) NOT NULL,
    [DataTypeId]                    INT            NOT NULL,
    [Value]                         NVARCHAR (MAX) NOT NULL,
    [ListId]                        INT            NULL,
    CONSTRAINT [PK_ApplicationSettings] PRIMARY KEY CLUSTERED ([ApplicationSettingId] ASC),
    CONSTRAINT [FK_ApplicationSettings_ApplicationSettingsCategories] FOREIGN KEY ([ApplicationSettingsCategoryId]) REFERENCES [AS].[ApplicationSettingsCategories] ([ApplicationSettingsCategoryId]),
    CONSTRAINT [FK_ApplicationSettings_DataSource] FOREIGN KEY ([ListId]) REFERENCES [AS].[DataSources] ([Id]),
    CONSTRAINT [FK_ApplicationSettings_DataTypes] FOREIGN KEY ([DataTypeId]) REFERENCES [ACT].[DataTypes] ([DataTypeId]),
    CONSTRAINT [uq_Category_Name] UNIQUE NONCLUSTERED ([ApplicationSettingsCategoryId] ASC, [Name] ASC)
);







