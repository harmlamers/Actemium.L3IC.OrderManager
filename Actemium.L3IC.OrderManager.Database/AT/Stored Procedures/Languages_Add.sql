
/* Adds a Language to the database */
CREATE PROCEDURE [AT].[Languages_Add] (
		@Id                               int OUTPUT,
		@Name                             nvarchar(50),
		@CultureName					  nvarchar(10),
		@Image							  varbinary(max)
) 
AS
	INSERT INTO [AT].[Languages] (
		[Name],
		[CultureName],
		[Image]
) VALUES (
		@Name,
		@CultureName,
		@Image
)
	SELECT @Id= SCOPE_IDENTITY();