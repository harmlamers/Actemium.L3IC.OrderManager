

/* Modifies an ApplicationSetting in the database */
CREATE PROCEDURE [AS].[ApplicationSettingsGennie_Modify] (
		@ApplicationSettingId             int,
		@ApplicationSettingsCategoryId    int,
		@Name                             nvarchar(100),
		@Description                      nvarchar(100),
		@DataTypeId                       int,
		@Value                            nvarchar(MAX),
		@ListId                           int
)
AS
	UPDATE [AS].[ApplicationSettings] SET
		[ApplicationSettings].[ApplicationSettingsCategoryId] = @ApplicationSettingsCategoryId, 
		[ApplicationSettings].[Name] = @Name, 
		[ApplicationSettings].[Description] = @Description, 
		[ApplicationSettings].[DataTypeId] = @DataTypeId, 
		[ApplicationSettings].[Value] = @Value, 
		[ApplicationSettings].[ListId] = @ListId
	WHERE
		[ApplicationSettings].[ApplicationSettingId] = @ApplicationSettingId