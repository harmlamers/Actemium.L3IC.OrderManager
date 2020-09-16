
/* Retrieves ApplicationTranslations from the database using one of it's foreign keys */
CREATE PROCEDURE [AT].[ApplicationTranslationsGennie_GetByLanguageId] (
@LanguageId                       int
)
AS
	SELECT *
	FROM [AT].[ApplicationTranslations]
	WHERE
			[LanguageId]=@LanguageId