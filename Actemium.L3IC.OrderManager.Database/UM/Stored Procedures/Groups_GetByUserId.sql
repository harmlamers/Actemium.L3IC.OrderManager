





/* Retrieves DBUserGroups from the database using one of it's foreign keys */
CREATE PROCEDURE [UM].[Groups_GetByUserId] (
@UserId                         int
)
AS
	SET NOCOUNT ON
	
	SELECT	G.*
	FROM	[UM].[Groups] G
			INNER JOIN [UM].[UserGroupLists] UG ON UG.[GroupId] = G.[Id]
	WHERE	[UserId]=@UserId