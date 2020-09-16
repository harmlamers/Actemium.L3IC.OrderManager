


CREATE PROCEDURE [AT].[ApplicationTranslations_GetNonTranslatedMessagesByLanguageId]
(
	@DefaultLanguageId int,
	@LanguageId int
)
AS

SELECT *
FROM ApplicationTranslations A
WHERE LanguageId = @DefaultLanguageId
AND NOT EXISTS 
(
	SELECT *
	FROM ApplicationTranslations B
	WHERE LanguageId = @LanguageId
		AND A.[Key] = B.[Key]
		AND A.[SubKey] = B.[SubKey]
)