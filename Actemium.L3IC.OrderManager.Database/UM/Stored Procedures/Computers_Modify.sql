




CREATE PROCEDURE [UM].[Computers_Modify] (
		@Id int,
		@HostName nvarchar(50),
		@Description nvarchar(25),
		@ACIManaged bit
	) 
AS

UPDATE		[UM].[Computers]
SET				[HostName] = @HostName,
					[Description] = @Description,
					[ACIManaged] = @ACIManaged
WHERE			[Id] = @Id;