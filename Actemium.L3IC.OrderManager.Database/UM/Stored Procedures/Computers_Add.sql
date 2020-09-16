




/* Adds a System to the database */
CREATE PROCEDURE [UM].[Computers_Add] (
		@Id int OUTPUT,
		@HostName nvarchar(50),
		@Description nvarchar(25),
		@ACIManaged bit
) 
AS

SET NOCOUNT ON

INSERT INTO [UM].[Computers]
						([HostName], [Description], [ACIManaged])
VALUES			(@HostName, @Description, @ACIManaged) 

SELECT @Id= SCOPE_IDENTITY();