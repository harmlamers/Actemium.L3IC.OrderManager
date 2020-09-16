

/* Modifies an HistoryKey in the database */
CREATE PROCEDURE [HIST].[HistoryKeysGennie_Modify] (
		@HistoryKey                       nvarchar(100),
		@ShowInClient                     bit,
		@SaveInDatabase                   bit,
		@TraceLevel                       nvarchar(100)
)
AS
	UPDATE [HIST].[HistoryKeys] SET
		[HistoryKeys].[ShowInClient] = @ShowInClient, 
		[HistoryKeys].[SaveInDatabase] = @SaveInDatabase, 
		[HistoryKeys].[TraceLevel] = @TraceLevel
	WHERE
		[HistoryKeys].[HistoryKey] = @HistoryKey