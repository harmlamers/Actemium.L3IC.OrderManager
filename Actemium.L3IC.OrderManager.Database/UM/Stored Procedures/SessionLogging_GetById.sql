CREATE PROCEDURE [UM].[SessionLogging_GetById]
@Id INT

AS
	 
	SELECT * 
	FROM um.SessionLogging
	WHERE Id = @Id