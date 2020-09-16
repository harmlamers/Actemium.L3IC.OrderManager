


/* Deletes a Language from the database */
CREATE PROCEDURE [AT].[Languages_Delete] (
		@Id                               int
) 
AS
	DELETE FROM [AT].[Languages] WHERE (
		[Id] = @Id
)