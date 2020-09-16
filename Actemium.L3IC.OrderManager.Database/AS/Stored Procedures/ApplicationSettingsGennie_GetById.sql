
/* Retrieves one ApplicationSetting from the database using its primary key */
CREATE PROCEDURE [AS].[ApplicationSettingsGennie_GetById] (
		@ApplicationSettingId             int
)
AS
	SELECT *
	FROM [AS].[ApplicationSettings]
	WHERE
		[ApplicationSettings].[ApplicationSettingId] = @ApplicationSettingId