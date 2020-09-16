





/* Adds a UserAccessControlList to the database */
CREATE PROCEDURE [UM].[UserAccessControlLists_Add] (
		@AccessControlListId         int,
		@UserId                      int
) 
AS

IF NOT EXISTS(	SELECT	* 
				FROM	[UM].[UserAccessControlLists] 
				WHERE	[AccessControlListId] = @AccessControlListId
						AND [UserId] = @UserId)
BEGIN
		INSERT INTO [UM].[UserAccessControlLists] 
					(
						[AccessControlListId],
						[UserId]
					) 
					VALUES
					(
						@AccessControlListId,
						@UserId
					)
END