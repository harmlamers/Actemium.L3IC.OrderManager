






/* Modifies an Group in the database */
CREATE PROCEDURE [UM].[Groups_Modify] (
		@Id                               int,
		@Name															nvarchar(50),
		@Description											nvarchar(255),
		@DomainGroupIdentifier						nvarchar(255)
)
AS
	UPDATE [UM].[Groups] SET
		[Groups].[Name] = @Name, 
		[Groups].[Description] = @Description, 
		[Groups].[DomainGroupIdentifier] = @DomainGroupIdentifier
	WHERE
		[Groups].[Id] = @Id