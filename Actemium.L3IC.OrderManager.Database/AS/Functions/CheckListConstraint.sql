CREATE FUNCTION [AS].CheckListConstraint
(
	@Object_Id INT, 
	@Key_Column_Id INT,
	@Value_Column_Id INT
)
RETURNS BIT
AS
BEGIN
	IF (
		EXISTS(SELECT 1 FROM sys.objects WHERE object_id = @Object_Id AND [type] in ('S', 'U', 'V')) AND
		EXISTS(SELECT 1 FROM sys.columns WHERE object_id = @Object_Id AND [column_id] = @Key_Column_Id) AND 
		EXISTS(SELECT 1 FROM sys.columns WHERE object_id = @Object_Id AND [column_id] = @Value_Column_Id)
	)
	BEGIN
		RETURN 1
	END
	
	RETURN 0;
END;