






/* Retrieves all Systems from the database */
CREATE PROCEDURE [UM].[Computers_GetByHostName] (
		@HostName                               nvarchar(50)
)
AS
SELECT	*
FROM	[UM].[Computers]
WHERE	HostName = @HostName