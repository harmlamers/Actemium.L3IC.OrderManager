CREATE PROCEDURE [UM].[SessionLogging_Add](
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

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO UM.SessionLogging(UserId,ComputerId,HostComputerName,ClientComputerName,Starttime,Endtime,LastActivity)
	VALUES( @UserId, @ComputerId, @HostComputerName, @ClientComputerName, @Starttime, @Endtime, @LastActivity)

	SELECT @Id = SCOPE_IDENTITY();