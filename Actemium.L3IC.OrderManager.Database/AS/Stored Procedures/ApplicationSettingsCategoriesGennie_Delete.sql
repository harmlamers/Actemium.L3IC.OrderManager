
/* Deletes a ApplicationSettingsCategory from the database */
CREATE PROCEDURE [AS].[ApplicationSettingsCategoriesGennie_Delete] (
		@ApplicationSettingsCategoryId    int
)
AS
	DELETE FROM [AS].[ApplicationSettingsCategories] WHERE (
		[ApplicationSettingsCategoryId] = @ApplicationSettingsCategoryId
)