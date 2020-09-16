

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [UM].[ViewUserPropertyValues_GetByPropertyAndUser]
	-- Add the parameters for the stored procedure here
	@PropertyId int,
	@UserId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM UM.ViewUserPropertyValues
	WHERE PropertyId = @PropertyId AND UserId = @UserId
END