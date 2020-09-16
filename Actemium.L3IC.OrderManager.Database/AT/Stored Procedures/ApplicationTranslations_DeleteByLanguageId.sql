

/*****************************************************************************************************************************************************/

/* Deletes a ApplicationTranslation from the database */
CREATE PROCEDURE [AT].[ApplicationTranslations_DeleteByLanguageId] (
		@LanguageId                               int
) 
AS
	DELETE FROM [AT].[ApplicationTranslations] WHERE (
		[LanguageId] = @LanguageId
		AND NOT EXISTS (SELECT * FROM AT.ApplicationTranslationsHistory h WHERE h.TranslationId = AT.ApplicationTranslations.Id)
)