


/* Retrieves one Language from the database using its primary key */
CREATE PROCEDURE [AT].[Languages_GetById] (
		@Id                               int
)
AS
	SELECT *
	FROM [AT].[Languages]
	WHERE
		[Languages].[Id] = @Id