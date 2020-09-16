CREATE PROCEDURE [UM].[SessionLogging_ModifyTime](
	@Id					INT,
	
	@EndTime			DATETIME,
	@LastActivity		DATETIME)
AS

UPDATE UM.SessionLogging
SET 
	Endtime				= @EndTime,
	LastActivity		= @LastActivity
WHERE id = @Id;