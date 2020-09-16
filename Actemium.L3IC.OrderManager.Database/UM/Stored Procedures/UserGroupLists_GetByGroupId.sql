


/* Retrieves one Property from the database using its primary key */
CREATE PROCEDURE [UM].[UserGroupLists_GetByGroupId] (
		@GroupId                       int
)
AS
	SELECT *
	FROM [UM].[UserGroupLists]
	WHERE
		[UserGroupLists].[GroupId] = @GroupId