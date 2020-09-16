


/* Deletes a ComputerPropertyValue from the database */
CREATE PROCEDURE [UM].[ComputerPropertyValuesGennie_Delete] (
		@PropertyId                       int,
		@ComputerId                       int
)
AS
	DELETE FROM [UM].[ComputerPropertyValues] WHERE (
		[PropertyId] = @PropertyId AND 
		[ComputerId] = @ComputerId
)