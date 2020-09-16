



/* Modifies an ComputerPropertyValue in the database */
CREATE PROCEDURE [UM].[ComputerPropertyValuesGennie_Modify] (
		@PropertyId                       int,
		@ComputerId                       int,
		@Value                            nvarchar(200)
)
AS
	UPDATE [UM].[ComputerPropertyValues] SET
		[ComputerPropertyValues].[Value] = @Value
	WHERE
		[ComputerPropertyValues].[PropertyId] = @PropertyId AND 
		[ComputerPropertyValues].[ComputerId] = @ComputerId