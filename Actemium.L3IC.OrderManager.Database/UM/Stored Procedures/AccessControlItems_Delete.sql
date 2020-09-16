/* Deletes a AccessControlItem from the database */
CREATE PROCEDURE [UM].[AccessControlItems_Delete] (
		@Id                               int
) 
AS
	DELETE FROM [UM].[AccessControlItems] WHERE (
		[Id] = @Id
)