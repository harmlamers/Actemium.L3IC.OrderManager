


/* Retrieves one Property from the database using its primary key */
CREATE PROCEDURE [UM].[PropertiesGennie_GetById] (
		@Id                       int
)
AS
	SELECT *
	FROM [UM].[Properties]
	WHERE
		[Properties].[Id] = @Id