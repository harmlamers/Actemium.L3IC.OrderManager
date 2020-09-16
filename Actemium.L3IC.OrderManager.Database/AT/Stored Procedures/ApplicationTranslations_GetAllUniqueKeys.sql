


/* Retrieves all unique ApplicationTranslations from the database */
CREATE PROCEDURE [AT].[ApplicationTranslations_GetAllUniqueKeys]
AS
SELECT [Key]
FROM [AT].[ApplicationTranslations]
GROUP BY [ApplicationTranslations].[Key]