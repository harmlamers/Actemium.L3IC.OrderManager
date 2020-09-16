
/* Deletes a HistoryAction from the database */
CREATE PROCEDURE [HIST].[HistoryActionsGennie_Delete] (
		@HistoryActionId                  bigint
)
AS
	DELETE FROM [HIST].[HistoryActions] WHERE (
		[HistoryActionId] = @HistoryActionId
)