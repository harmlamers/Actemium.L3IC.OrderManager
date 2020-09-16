
CREATE PROCEDURE [AT].[ApplicationTranslations_Translate] (
		@Result		nvarchar(max) OUTPUT,
		@Key		nvarchar(50),
		@SubKey		nvarchar(100),
		@LanguageId	int
)
AS
	SELECT @Result = [ApplicationTranslations].[Value]
	FROM [AT].[ApplicationTranslations]
	WHERE [ApplicationTranslations].[Key] = @Key
		AND [ApplicationTranslations].[SubKey] = @SubKey
		AND [ApplicationTranslations].[LanguageId] = @LanguageId