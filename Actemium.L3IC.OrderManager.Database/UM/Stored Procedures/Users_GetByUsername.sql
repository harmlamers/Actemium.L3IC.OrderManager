





/* Retrieves all DBUsers from the database */
CREATE PROCEDURE [UM].[Users_GetByUsername] (
		@Username                               nvarchar(50)
)
AS
SELECT	*
FROM	[UM].[Users]
WHERE	username = @Username