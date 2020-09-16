


/* Adds a UserPropertyValue to the database */
CREATE PROCEDURE [UM].[UserPropertyValuesGennie_Add] (
		@PropertyId                       int,
		@UserId                           int,
		@Value                            nvarchar(200)
)
AS
	INSERT INTO [UM].[UserPropertyValues] (
		[PropertyId],
		[UserId],
		[Value]
) VALUES (
		@PropertyId,
		@UserId,
		@Value
)