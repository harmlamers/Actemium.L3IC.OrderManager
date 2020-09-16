





/* Adds a DBUser to the database */
CREATE PROCEDURE [UM].[Users_Add] (
		@Id int OUTPUT,
		@Username nvarchar(50),
		@Password nvarchar(200),
		@Name nvarchar(25),
		@SurName nvarchar(25),
		@AccountType integer,
		@IsActive bit
) 
AS

SET NOCOUNT ON

-- ADD User
INSERT INTO [UM].[Users]
	([Username], [Password], [Name], [SurName], [AccountType], [IsActive])
VALUES (@Username, @Password, @Name, @SurName, @AccountType, @IsActive)

SELECT @Id= SCOPE_IDENTITY();