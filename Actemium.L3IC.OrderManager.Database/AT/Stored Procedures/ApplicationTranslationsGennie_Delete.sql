

/* Deletes a ApplicationTranslation from the database */
CREATE PROCEDURE [AT].[ApplicationTranslationsGennie_Delete] (
		@Id                               int
) 
AS
	DELETE FROM [AT].[ApplicationTranslations] WHERE (
		[Id] = @Id
)