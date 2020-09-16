
/* Deletes a ApplicationSetting from the database */
CREATE PROCEDURE [AS].[ApplicationSettingsGennie_Delete] (
		@ApplicationSettingId             int
)
AS
	DELETE FROM [AS].[ApplicationSettings] WHERE (
		[ApplicationSettingId] = @ApplicationSettingId
)