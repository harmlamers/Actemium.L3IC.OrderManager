CREATE TABLE [AT].[ApplicationTranslations] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Key]        NVARCHAR (50)  NOT NULL,
    [SubKey]     NVARCHAR (100) NOT NULL,
    [LanguageId] INT            NOT NULL,
    [Value]      NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK__Applicat__3214EC07536D5C82] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ApplicationTranslations_Languages] FOREIGN KEY ([LanguageId]) REFERENCES [AT].[Languages] ([Id]),
    CONSTRAINT [IX_ApplicationTranslations] UNIQUE NONCLUSTERED ([Key] ASC, [SubKey] ASC, [LanguageId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_ApplicationTranslationsLanguages]
    ON [AT].[ApplicationTranslations]([LanguageId] ASC);


GO


CREATE TRIGGER [AT].[ApplicationTranslationsChanged] 
   ON  [AT].[ApplicationTranslations]
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF NOT EXISTS (SELECT * FROM AT.ApplicationTranslationsUpdatedOn)
	BEGIN
		INSERT INTO [AT].ApplicationTranslationsUpdatedOn ([Date]) VALUES (GetUtcDate())
	END
	ELSE
	BEGIN
		UPDATE [AT].ApplicationTranslationsUpdatedOn SET  [Date]=GetUtcDate()
	END

	INSERT INTO AT.ApplicationTranslationsHistory (TranslationId, [Key], SubKey, LanguageId, Value, Modified_On, Column_Updated_BitMask)
		SELECT inserted.Id, inserted.[Key], inserted.SubKey, inserted.LanguageId, '', GETUTCDATE(), 'add' FROM inserted WHERE
			Id NOT IN (SELECT Id FROM deleted)

	INSERT INTO AT.ApplicationTranslationsHistory (TranslationId, [Key], SubKey, LanguageId, Value, Modified_On, Column_Updated_BitMask)
		SELECT deleted.Id, deleted.[Key], deleted.SubKey, deleted.LanguageId, deleted.Value, GETUTCDATE(), CAST(COLUMNS_UPDATED() as varchar(15)) FROM inserted inner join deleted 
		on inserted.Id = deleted.Id
	
	INSERT INTO AT.ApplicationTranslationsHistory (TranslationId, [Key], SubKey, LanguageId, Value, Modified_On, Column_Updated_BitMask)
		SELECT Id, [Key], SubKey, LanguageId, Value, GETUTCDATE(), 'deleted' FROM deleted WHERE
			Id NOT IN (SELECT Id FROM inserted)

END