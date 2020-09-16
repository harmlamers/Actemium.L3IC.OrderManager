
/* Adds a ApplicationSettingsCategory to the database */
CREATE PROCEDURE [AS].[ApplicationSettingsCategoriesGennie_Add] (
		@ApplicationSettingsCategoryId    int,
		@Name                             nvarchar(100),
		@Description                      nvarchar(100)
)
AS
	INSERT INTO [AS].[ApplicationSettingsCategories] (
		[ApplicationSettingsCategoryId],
		[Name],
		[Description]
) VALUES (
		@ApplicationSettingsCategoryId,
		@Name,
		@Description
)