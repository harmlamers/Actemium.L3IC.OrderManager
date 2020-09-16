
/* Retrieves HistoryActions from the database using one of it's foreign keys */
CREATE PROCEDURE [HIST].[HistoryActionsGennie_GetByUserId] (
@UserId                           int
)
AS
	SELECT *
	FROM [HIST].[HistoryActions]
	WHERE
			[UserId]=@UserId OR (@UserId is NULL AND UserId is NULL)