





/* Retrieves one Group from the database using its primary key */
CREATE PROCEDURE [UM].[Groups_GetById] (
		@Id                               int
)
AS
	SELECT *
	FROM [UM].[Groups]
	WHERE
		[Groups].[Id] = @Id