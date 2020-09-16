



/* Modifies an UserPropertyValue in the database */
CREATE PROCEDURE [UM].[UserPropertyValuesGennie_Modify] (
		@PropertyId                       int,
		@UserId                           int,
		@Value                            nvarchar(200)
)
AS
	UPDATE [UM].[UserPropertyValues] SET
		[UserPropertyValues].[Value] = @Value
	WHERE
		[UserPropertyValues].[PropertyId] = @PropertyId AND 
		[UserPropertyValues].[UserId] = @UserId