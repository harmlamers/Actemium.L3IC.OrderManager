CREATE PROCEDURE [UM].[SessionLogging_Modify](
	-- Add the parameters for the stored procedure here
	@Id					INT OUTPUT,
	@UserId				INT,
	@ComputerId			INT,
	@HostComputerName	NVARCHAR(50),
	@ClientComputerName	NVARCHAR(50),
	@StartTime			DATETIME,
	@EndTime			DATETIME,
	@LastActivity		DATETIME)
AS

UPDATE UM.SessionLogging
SET UserId				= @Id,
	ComputerId			= @ComputerId,
	HostComputerName	= @HostComputerName,
	ClientComputerName	= @ClientComputerName,
	Starttime			= @StartTime,
	Endtime				= @EndTime,
	LastActivity		= @LastActivity
WHERE id = @Id;