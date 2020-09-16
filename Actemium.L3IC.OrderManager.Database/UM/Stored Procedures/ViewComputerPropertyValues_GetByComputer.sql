


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [UM].[ViewComputerPropertyValues_GetByComputer]
	-- Add the parameters for the stored procedure here
	@ComputerId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

 --   -- Insert statements for procedure here
	--SELECT * FROM UM.ViewUserPropertyValues
	--WHERE PropertyId = @PropertyId AND UserId = @UserId


	SELECT * 
	FROM UM.ViewComputerPropertyValues
	WHERE ComputerId = @ComputerId

	UNION

	SELECT Id as PropertyId, Name, DefaultValue, DataType, NULL as UserId, NULL as Value FROM UM.Properties
	WHERE Id NOT IN (
		SELECT PropertyId 
		FROM UM.ViewComputerPropertyValues
		WHERE ComputerId = @ComputerId)
	AND [Type] = 2

END