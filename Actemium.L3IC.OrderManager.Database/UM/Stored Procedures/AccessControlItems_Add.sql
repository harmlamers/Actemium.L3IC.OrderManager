
/* Adds a AccessControlItem to the database */
CREATE PROCEDURE [UM].[AccessControlItems_Add] (
		@Id                               int OUTPUT,
		@Category                         nvarchar(100),
		@Action                           nvarchar(100)
) 
AS
	INSERT INTO [UM].[AccessControlItems] (
		[Category],
		[Action]
) VALUES (
		@Category,
		@Action
)
	SELECT @Id= SCOPE_IDENTITY();