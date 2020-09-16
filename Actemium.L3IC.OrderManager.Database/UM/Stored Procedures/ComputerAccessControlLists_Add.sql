
/* Adds a SystemAccessControlList to the database */
CREATE PROCEDURE [UM].[ComputerAccessControlLists_Add] (
		@AccessControlListId         int,
		@ComputerId                      int
) 
AS

IF NOT EXISTS(	SELECT	* 
				FROM	[UM].[ComputerAccessControlLists] 
				WHERE	[AccessControlListId] = @AccessControlListId
						AND [ComputerId] = @ComputerId)
BEGIN
		INSERT INTO [UM].[ComputerAccessControlLists] 
					(
						[AccessControlListId],
						[ComputerId]
					) 
					VALUES
					(
						@AccessControlListId,
						@ComputerId
					)
END