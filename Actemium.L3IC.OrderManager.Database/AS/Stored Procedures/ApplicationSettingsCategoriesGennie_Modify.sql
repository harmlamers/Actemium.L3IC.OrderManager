

/* Modifies an ApplicationSettingsCategory in the database */
CREATE PROCEDURE [AS].[ApplicationSettingsCategoriesGennie_Modify] (
		@ApplicationSettingsCategoryId    int,
		@Name                             nvarchar(100),
		@Description                      nvarchar(100)
)
AS
	UPDATE [AS].[ApplicationSettingsCategories] SET
		[ApplicationSettingsCategories].[Name] = @Name, 
		[ApplicationSettingsCategories].[Description] = @Description
	WHERE
		[ApplicationSettingsCategories].[ApplicationSettingsCategoryId] = @ApplicationSettingsCategoryId