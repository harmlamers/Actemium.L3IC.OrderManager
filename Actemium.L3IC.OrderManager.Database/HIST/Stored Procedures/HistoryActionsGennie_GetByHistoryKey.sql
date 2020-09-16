
/* Retrieves HistoryActions from the database using one of it's foreign keys */
CREATE PROCEDURE [HIST].[HistoryActionsGennie_GetByHistoryKey] (
@HistoryKey                       nvarchar(100)
)
AS
	SELECT *
	FROM [HIST].[HistoryActions]
	WHERE
			[HistoryKey]=@HistoryKey