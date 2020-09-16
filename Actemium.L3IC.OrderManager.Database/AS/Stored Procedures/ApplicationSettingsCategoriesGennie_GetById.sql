
/* Retrieves one ApplicationSettingsCategory from the database using its primary key */
CREATE PROCEDURE [AS].[ApplicationSettingsCategoriesGennie_GetById] (
		@ApplicationSettingsCategoryId    int
)
AS
	SELECT *
	FROM [AS].[ApplicationSettingsCategories]
	WHERE
		[ApplicationSettingsCategories].[ApplicationSettingsCategoryId] = @ApplicationSettingsCategoryId