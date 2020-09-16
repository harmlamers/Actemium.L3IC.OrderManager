


/* Retrieves one ComputerPropertyValue from the database using its primary key */
CREATE PROCEDURE [UM].[ComputerPropertyValuesGennie_GetById] (
		@PropertyId                       int,
		@ComputerId                       int
)
AS
	SELECT *
	FROM [UM].[ComputerPropertyValues]
	WHERE
		[ComputerPropertyValues].[PropertyId] = @PropertyId AND 
		[ComputerPropertyValues].[ComputerId] = @ComputerId