
/* Deletes a HistoryKey from the database */
CREATE PROCEDURE [HIST].[HistoryKeysGennie_Delete] (
		@HistoryKey                       nvarchar(100)
)
AS
	DELETE FROM [HIST].[HistoryKeys] WHERE (
		[HistoryKey] = @HistoryKey
)