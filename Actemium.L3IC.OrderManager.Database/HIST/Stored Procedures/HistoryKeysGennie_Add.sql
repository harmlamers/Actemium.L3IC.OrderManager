
/* Adds a HistoryKey to the database */
CREATE PROCEDURE [HIST].[HistoryKeysGennie_Add] (
		@HistoryKey                       nvarchar(100),
		@ShowInClient                     bit,
		@SaveInDatabase                   bit,
		@TraceLevel                       nvarchar(100)
)
AS
	INSERT INTO [HIST].[HistoryKeys] (
		[HistoryKey],
		[ShowInClient],
		[SaveInDatabase],
		[TraceLevel]
) VALUES (
		@HistoryKey,
		@ShowInClient,
		@SaveInDatabase,
		@TraceLevel
)