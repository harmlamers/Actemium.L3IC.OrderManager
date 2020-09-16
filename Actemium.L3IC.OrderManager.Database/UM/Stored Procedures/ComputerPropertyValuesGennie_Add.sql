


/* Adds a ComputerPropertyValue to the database */
CREATE PROCEDURE [UM].[ComputerPropertyValuesGennie_Add] (
		@PropertyId                       int,
		@ComputerId                       int,
		@Value                            nvarchar(200)
)
AS
	INSERT INTO [UM].[ComputerPropertyValues] (
		[PropertyId],
		[ComputerId],
		[Value]
) VALUES (
		@PropertyId,
		@ComputerId,
		@Value
)