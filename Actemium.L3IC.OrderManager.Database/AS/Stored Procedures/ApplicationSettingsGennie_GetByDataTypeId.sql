
/* Retrieves ApplicationSettings from the database using one of it's foreign keys */
CREATE PROCEDURE [AS].[ApplicationSettingsGennie_GetByDataTypeId] (
@DataTypeId                       int
)
AS
	SELECT *
	FROM [AS].[ApplicationSettings]
	WHERE
			[DataTypeId]=@DataTypeId