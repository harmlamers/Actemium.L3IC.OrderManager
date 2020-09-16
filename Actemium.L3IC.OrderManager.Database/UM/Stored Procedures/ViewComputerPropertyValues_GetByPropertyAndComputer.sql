


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [UM].[ViewComputerPropertyValues_GetByPropertyAndComputer]
	-- Add the parameters for the stored procedure here
	@PropertyId int,
	@ComputerId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM UM.ViewComputerPropertyValues
	WHERE PropertyId = @PropertyId AND ComputerId = @ComputerId
END