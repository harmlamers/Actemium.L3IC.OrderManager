





/* Deletes a Group from the database */
CREATE PROCEDURE [UM].[Groups_Delete] (
		@Id                               int
) 
AS
	DELETE FROM [UM].[Groups] WHERE (
		[Id] = @Id
)