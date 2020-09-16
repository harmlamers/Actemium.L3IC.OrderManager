
/* Retrieves one HistoryKey from the database using its primary key */
CREATE PROCEDURE [HIST].[HistoryKeysGennie_GetById] (
		@HistoryKey                       nvarchar(100)
)
AS
	SELECT *
	FROM [HIST].[HistoryKeys]
	WHERE
		[HistoryKeys].[HistoryKey] = @HistoryKey