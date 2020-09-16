






/* Deletes a SystemAccessControlList from the database */
CREATE PROCEDURE [UM].[ComputerAccessControlLists_Delete] (
		@AccessControlListId         int,
		@ComputerId                      int
) 
AS
	DELETE FROM [UM].[ComputerAccessControlLists] WHERE (
						[AccessControlListId] = @AccessControlListId
						AND [ComputerId] = @ComputerId
)