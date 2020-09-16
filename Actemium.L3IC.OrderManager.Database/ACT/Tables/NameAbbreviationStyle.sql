CREATE TABLE [ACT].[NameAbbreviationStyle] (
    [NameAbbreviationStyleId] INT            NOT NULL,
    [Name]                    NVARCHAR (50)  NOT NULL,
    [Description]             NVARCHAR (100) NULL,
    CONSTRAINT [PK_NameAbbreviationStyle] PRIMARY KEY CLUSTERED ([NameAbbreviationStyleId] ASC)
);

