
/* Retrieves HistoryActions from the database using one of it's foreign keys */
CREATE PROCEDURE [HIST].[HistoryActionsGennie_GetByComputerId] (
@ComputerId                       int
)
AS
	SELECT *
	FROM [HIST].[HistoryActions]
	WHERE
			[ComputerId]=@ComputerId OR (@ComputerId is NULL AND ComputerId is NULL)