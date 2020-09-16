





/* Adds a GroupAccessControlList to the database */
CREATE PROCEDURE [UM].[GroupAccessControlLists_Add] (
		@AccessControlListId              int,
		@GroupId                      int
) 
AS


IF NOT EXISTS(	SELECT	* 
				FROM	[UM].[GroupAccessControlLists] 
				WHERE	[AccessControlListId] = @AccessControlListId
						AND [GroupId] = @GroupId)
BEGIN
		INSERT INTO [UM].[GroupAccessControlLists] 
					(
						[AccessControlListId],
						[GroupId]
					) 
					VALUES
					(
						@AccessControlListId,
						@GroupId
					)
END