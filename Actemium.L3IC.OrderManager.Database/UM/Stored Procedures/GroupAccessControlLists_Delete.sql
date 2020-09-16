





/* Deletes a GroupAccessControlList from the database */
CREATE PROCEDURE [UM].[GroupAccessControlLists_Delete] (
		@AccessControlListId              int,
		@GroupId		                      int
) 
AS
	DELETE
	FROM	[UM].[GroupAccessControlLists]
	WHERE	[AccessControlListId] = @AccessControlListId
			AND [GroupId] = @GroupId