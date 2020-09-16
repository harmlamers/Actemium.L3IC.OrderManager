


/* Retrieves one UserPropertyValue from the database using its primary key */
CREATE PROCEDURE [UM].[UserPropertyValuesGennie_GetById] (
		@PropertyId                       int,
		@UserId                           int
)
AS
	SELECT *
	FROM [UM].[UserPropertyValues]
	WHERE
		[UserPropertyValues].[PropertyId] = @PropertyId AND 
		[UserPropertyValues].[UserId] = @UserId