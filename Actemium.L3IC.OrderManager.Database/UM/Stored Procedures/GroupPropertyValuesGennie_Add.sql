


/* Adds a GroupPropertyValue to the database */
CREATE PROCEDURE [UM].[GroupPropertyValuesGennie_Add] (
		@PropertyId                       int,
		@GroupId                          int,
		@Value                            nvarchar(200)
)
AS
	INSERT INTO [UM].[GroupPropertyValues] (
		[PropertyId],
		[GroupId],
		[Value]
) VALUES (
		@PropertyId,
		@GroupId,
		@Value
)