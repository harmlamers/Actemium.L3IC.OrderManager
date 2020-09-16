


/* Retrieves one GroupPropertyValue from the database using its primary key */
CREATE PROCEDURE [UM].[GroupPropertyValuesGennie_GetById] (
		@PropertyId                       int,
		@GroupId                          int
)
AS
	SELECT *
	FROM [UM].[GroupPropertyValues]
	WHERE
		[GroupPropertyValues].[PropertyId] = @PropertyId AND 
		[GroupPropertyValues].[GroupId] = @GroupId