





/* Deletes a DBUserGroup from the database */
CREATE PROCEDURE [UM].[UserGroupLists_Delete] (
		@UserId                         int,
		@GroupId                          int
) 
AS
	DELETE FROM [UM].[UserGroupLists] WHERE (
		[UserId] = @UserId
		AND [GroupId] = @GroupId
)