CREATE TABLE [AT].[ApplicationTranslationsHistory] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [TranslationId]          INT            NOT NULL,
    [Key]                    NVARCHAR (50)  NOT NULL,
    [SubKey]                 NVARCHAR (100) NOT NULL,
    [LanguageId]             INT            NOT NULL,
    [Value]                  NVARCHAR (MAX) NOT NULL,
    [Modified_On]            DATETIME       NOT NULL,
    [Column_Updated_BitMask] VARCHAR (15)   NOT NULL,
    CONSTRAINT [PK__ApplicationTranslationsHistory__Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

