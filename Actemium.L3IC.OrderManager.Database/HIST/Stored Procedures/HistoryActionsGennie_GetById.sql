
/* Retrieves one HistoryAction from the database using its primary key */
CREATE PROCEDURE [HIST].[HistoryActionsGennie_GetById] (
		@HistoryActionId                  bigint
)
AS
	SELECT *
	FROM [HIST].[HistoryActions]
	WHERE
		[HistoryActions].[HistoryActionId] = @HistoryActionId