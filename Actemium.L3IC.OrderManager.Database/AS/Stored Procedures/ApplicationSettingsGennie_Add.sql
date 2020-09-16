
/* Adds a ApplicationSetting to the database */
CREATE PROCEDURE [AS].[ApplicationSettingsGennie_Add] (
		@ApplicationSettingId             int,
		@ApplicationSettingsCategoryId    int,
		@Name                             nvarchar(100),
		@Description                      nvarchar(100),
		@DataTypeId                       int,
		@Value                            nvarchar(MAX),
		@ListId                           int
)
AS
	INSERT INTO [AS].[ApplicationSettings] (
		[ApplicationSettingId],
		[ApplicationSettingsCategoryId],
		[Name],
		[Description],
		[DataTypeId],
		[Value],
		[ListId]
) VALUES (
		@ApplicationSettingId,
		@ApplicationSettingsCategoryId,
		@Name,
		@Description,
		@DataTypeId,
		@Value,
		@ListId
)