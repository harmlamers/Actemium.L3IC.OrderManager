
/* Retrieves ApplicationSettings from the database using one of it's foreign keys */
CREATE PROCEDURE [AS].[ApplicationSettingsGennie_GetByApplicationSettingsCategoryId] (
@ApplicationSettingsCategoryId    int
)
AS
	SELECT *
	FROM [AS].[ApplicationSettings]
	WHERE
			[ApplicationSettingsCategoryId]=@ApplicationSettingsCategoryId