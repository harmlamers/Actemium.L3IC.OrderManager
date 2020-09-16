

/* Modifies an HistoryAction in the database */
CREATE PROCEDURE [HIST].[HistoryActionsGennie_Modify] (
		@HistoryActionId                  bigint,
		@HistoryKey                       nvarchar(100),
		@TimeStampUTC                     datetime,
		@UserId                           int,
		@ComputerId                       int,
		@Parameters                       xml
)
AS
	UPDATE [HIST].[HistoryActions] SET
		[HistoryActions].[HistoryKey] = @HistoryKey, 
		[HistoryActions].[TimeStampUTC] = @TimeStampUTC, 
		[HistoryActions].[UserId] = @UserId, 
		[HistoryActions].[ComputerId] = @ComputerId, 
		[HistoryActions].[Parameters] = @Parameters
	WHERE
		[HistoryActions].[HistoryActionId] = @HistoryActionId