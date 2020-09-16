CREATE PROCEDURE [AT].[ApplicationTranslations_GetNewOrModifiedSince]
 @Since datetime
AS
	SELECT * FROM AT.ApplicationTranslations  WHERE
		ApplicationTranslations.Id IN (
			SELECT AT.ApplicationTranslationsHistory.TranslationId FROM AT.ApplicationTranslationsHistory 
				WHERE AT.ApplicationTranslationsHistory.Modified_On > @Since AND AT.ApplicationTranslationsHistory.Column_Updated_BitMask <> 'deleted')
				AND ApplicationTranslations.Id NOT IN (
			SELECT AT.ApplicationTranslationsHistory.TranslationId FROM AT.ApplicationTranslationsHistory 
				WHERE AT.ApplicationTranslationsHistory.Modified_On > @Since
				AND AT.ApplicationTranslationsHistory.Column_Updated_BitMask = 'deleted')