

/* Modifies an Language in the database */
CREATE PROCEDURE [AT].[Languages_Modify] (
		@Id                               int,
		@Name                             nvarchar(50),
		@CultureName					  nvarchar(10),
		@Image							  varbinary(max)
)
AS
	UPDATE [AT].[Languages] SET
		[Languages].[Name] = @Name,
		[Languages].[CultureName] = @CultureName,
		[Languages].[Image] = @Image
	WHERE
		[Languages].[Id] = @Id