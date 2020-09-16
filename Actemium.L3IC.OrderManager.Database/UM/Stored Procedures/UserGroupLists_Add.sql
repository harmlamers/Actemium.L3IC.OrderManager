





/* Adds a DBUserGroup to the database */
CREATE PROCEDURE [UM].[UserGroupLists_Add] (
		@UserId                         nvarchar(50),
		@GroupId                          int
) 
AS

IF NOT EXISTS(	SELECT	* 
				FROM	[UM].[UserGroupLists] 
				WHERE	[UserId] = @UserId
						AND [GroupId] = @GroupId)
BEGIN
		INSERT INTO [UM].[UserGroupLists] (
		[UserId],
		[GroupId]
) VALUES (
		@UserId,
		@GroupId
)

END