



/* Modifies an GroupPropertyValue in the database */
CREATE PROCEDURE [UM].[GroupPropertyValuesGennie_Modify] (
		@PropertyId                       int,
		@GroupId                          int,
		@Value                            nvarchar(200)
)
AS
	UPDATE [UM].[GroupPropertyValues] SET
		[GroupPropertyValues].[Value] = @Value
	WHERE
		[GroupPropertyValues].[PropertyId] = @PropertyId AND 
		[GroupPropertyValues].[GroupId] = @GroupId