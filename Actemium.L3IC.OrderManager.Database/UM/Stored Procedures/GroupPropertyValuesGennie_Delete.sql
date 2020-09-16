


/* Deletes a GroupPropertyValue from the database */
CREATE PROCEDURE [UM].[GroupPropertyValuesGennie_Delete] (
		@PropertyId                       int,
		@GroupId                          int
)
AS
	DELETE FROM [UM].[GroupPropertyValues] WHERE (
		[PropertyId] = @PropertyId AND 
		[GroupId] = @GroupId
)