


/* Retrieves one Property from the database using its primary key */
CREATE PROCEDURE [UM].[UserGroupLists_GetByUserId] (
		@UserId                       int
)
AS
	SELECT *
	FROM [UM].[UserGroupLists]
	WHERE
		[UserGroupLists].[UserId] = @UserId