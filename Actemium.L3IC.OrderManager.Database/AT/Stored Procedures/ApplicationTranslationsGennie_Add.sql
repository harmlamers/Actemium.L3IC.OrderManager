

/* Adds a ApplicationTranslation to the database */
CREATE PROCEDURE [AT].[ApplicationTranslationsGennie_Add] (
		@Id                               int OUTPUT,
		@Key                             nvarchar(50),
		@SubKey                             nvarchar(100),
		@LanguageId                       int,
		@Value                            nvarchar(MAX)
) 
AS
	INSERT INTO [AT].[ApplicationTranslations] (
		[Key],
		[SubKey],
		[LanguageId],
		[Value]
) VALUES (
		@Key,
		@SubKey,
		@LanguageId,
		@Value
)
	SELECT @Id= SCOPE_IDENTITY();