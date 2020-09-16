CREATE PROCEDURE [AS].[DataSources_GetListById]
(
	@ListId AS INT,
	@Success AS BIT OUT,
	@ErrorMessage AS NVARCHAR(4000) OUT
)
AS
BEGIN
	
	DECLARE 
		@ObjectId INT,
		@KeyId INT, 
		@ValueId INT,
		@ObjectName NVARCHAR(128),
		@SchemaName NVARCHAR(128),
		@KeyName NVARCHAR(128),
		@ValueName NVARCHAR(128),
		@Sql NVARCHAR(MAX)

	IF NOT EXISTS (SELECT 1 FROM [AS].[DataSources] WHERE [Id] = @ListId)
	BEGIN
		SET @ErrorMessage = 'The selected list is not found'
		SET @Success = 0
		RETURN @Success
	END

	SELECT @ObjectId = [Object_Id], @KeyId = [Key_Column_Id], @ValueId = [Value_Column_Id] FROM [AS].[DataSources] WHERE [Id] = @ListId

	IF([AS].CheckListConstraint(@ObjectId, @KeyId, @ValueId) = 0)
	BEGIN
		SET @ErrorMessage = 'The checked constraints are not valid'
		SET @Success = 0
		RETURN @Success
	END
	
	SELECT @ObjectName = [objects].[name], @SchemaName = [schemas].[name] FROM [sys].[objects] LEFT JOIN [sys].[schemas] ON [objects].[schema_id] = [schemas].[schema_id] WHERE [object_id] = @ObjectId
	SELECT @KeyName = [name] FROM [sys].[columns] WHERE [object_id] = @ObjectId AND [column_id] = @KeyId
	SELECT @ValueName = [name] FROM [sys].[columns] WHERE [object_id] = @ObjectId AND [column_id] = @ValueId

	SET @Sql = N'SELECT CAST([' + @KeyName + '] as NVARCHAR(MAX)) as [Key], CAST([' + @ValueName +'] as NVARCHAR(MAX)) as [Value] FROM [' + @SchemaName + '].[' + @ObjectName + ']';
	SET @ErrorMessage = ''
	SET @Success = 1

	EXEC sp_executesql @Sql

	RETURN @Success
	
END