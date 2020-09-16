
/* Adds a HistoryAction to the database */
CREATE PROCEDURE [HIST].[HistoryActionsGennie_Add] (
		@HistoryActionId                  bigint OUTPUT,
		@HistoryKey                       nvarchar(100),
		@TimeStampUTC                     datetime,
		@UserId                           int,
		@ComputerId                       int,
		@Parameters                       xml
)
AS
	INSERT INTO [HIST].[HistoryActions] (
		[HistoryKey],
		[TimeStampUTC],
		[UserId],
		[ComputerId],
		[Parameters]
) VALUES (
		@HistoryKey,
		@TimeStampUTC,
		@UserId,
		@ComputerId,
		@Parameters
)
	SELECT @HistoryActionId= SCOPE_IDENTITY();