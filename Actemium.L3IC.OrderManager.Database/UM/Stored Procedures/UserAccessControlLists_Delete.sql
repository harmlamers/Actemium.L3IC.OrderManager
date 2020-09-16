





/* Deletes a UserAccessControlList from the database */
CREATE PROCEDURE [UM].[UserAccessControlLists_Delete] (
		@AccessControlListId         int,
		@UserId                      int
) 
AS
	DELETE FROM [UM].[UserAccessControlLists] WHERE (
						[AccessControlListId] = @AccessControlListId
						AND [UserId] = @UserId
)