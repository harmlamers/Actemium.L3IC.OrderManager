




CREATE PROCEDURE [UM].[Users_Modify] (
		@Id int,
		@Username nvarchar(50),
		@Password nvarchar(200),
		@Name nvarchar(25),
		@SurName nvarchar(25),
		@AccountType integer,
		@IsActive bit
	) 
AS

UPDATE		[UM].[Users]
SET			[UserName] = @UserName,
			[Password] = @Password,
			[Name] = @Name,
			[SurName] = @SurName,
			[AccountType] = @AccountType,
			[IsActive] = @IsActive
WHERE		[Id] = @Id;