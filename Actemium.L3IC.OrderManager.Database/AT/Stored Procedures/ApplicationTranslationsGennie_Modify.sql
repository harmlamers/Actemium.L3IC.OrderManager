


/* Modifies an ApplicationTranslation in the database */
CREATE PROCEDURE [AT].[ApplicationTranslationsGennie_Modify] (
		@Id                               int,
		@Key                             nvarchar(50),
		@SubKey                             nvarchar(100),
		@LanguageId                       int,
		@Value                            nvarchar(MAX)
)
AS
	UPDATE [AT].[ApplicationTranslations] SET
		[ApplicationTranslations].[Key] = @Key, 
		[ApplicationTranslations].[SubKey] = @SubKey, 
		[ApplicationTranslations].[LanguageId] = @LanguageId, 
		[ApplicationTranslations].[Value] = @Value
	WHERE
		[ApplicationTranslations].[Id] = @Id