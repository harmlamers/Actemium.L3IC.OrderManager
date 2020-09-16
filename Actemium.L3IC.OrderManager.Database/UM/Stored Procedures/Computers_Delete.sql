





/* Deletes a Group from the database */
CREATE PROCEDURE [UM].[Computers_Delete] (
		@Id                               int
) 
AS
	DELETE FROM [UM].[Computers] WHERE (
		[Id] = @Id
)