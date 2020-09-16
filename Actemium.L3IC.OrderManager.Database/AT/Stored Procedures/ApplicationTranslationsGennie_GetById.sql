


/* Retrieves one ApplicationTranslation from the database using its primary key */
CREATE PROCEDURE [AT].[ApplicationTranslationsGennie_GetById] (
		@Id                               int
)
AS
	SELECT *
	FROM [AT].[ApplicationTranslations]
	WHERE
		[ApplicationTranslations].[Id] = @Id