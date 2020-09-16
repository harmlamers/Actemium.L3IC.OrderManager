





/* Adds a Group to the database */
CREATE PROCEDURE [UM].[Groups_Add] (
		@Id                               int OUTPUT,
		@Name															nvarchar(50),
		@Description											nvarchar(255),
		@DomainGroupIdentifier						nvarchar(255)
) 
AS
	INSERT INTO [UM].[Groups] (
		[Name],
		[Description],
		[DomainGroupIdentifier]
) VALUES (
		@Name,
		@Description,
		@DomainGroupIdentifier
)
	SELECT @Id= SCOPE_IDENTITY();