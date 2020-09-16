
/* Retrieves ApplicationSettings from the database using one of it's foreign keys */
CREATE PROCEDURE [AS].[ApplicationSettingsGennie_GetByListId] (
@ListId                           int
)
AS
	SELECT *
	FROM [AS].[ApplicationSettings]
	WHERE
			[ListId]=@ListId OR (@ListId is NULL AND ListId is NULL)