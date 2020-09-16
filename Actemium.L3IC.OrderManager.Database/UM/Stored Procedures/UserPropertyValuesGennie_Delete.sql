


/* Deletes a UserPropertyValue from the database */
CREATE PROCEDURE [UM].[UserPropertyValuesGennie_Delete] (
		@PropertyId                       int,
		@UserId                           int
)
AS
	DELETE FROM [UM].[UserPropertyValues] WHERE (
		[PropertyId] = @PropertyId AND 
		[UserId] = @UserId
)