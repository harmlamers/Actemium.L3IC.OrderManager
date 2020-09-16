CREATE PROCEDURE [AT].[ApplicationTranslations_GetByKeyAndLanguageId](
  @Key nvarchar(50),
  @LanguageId int
)
AS
  SELECT *
  FROM [AT].[ApplicationTranslations]
  WHERE
    [Key] = @Key
	AND [LanguageId] = @LanguageId