
/* Adds a DataSource to the database */
CREATE PROCEDURE [AS].[DataSourcesGennie_Add] (
		@Id                               int OUTPUT,
		@ListName                         varchar(50),
		@Object_Id                        int,
		@Key_Column_Id                    int,
		@Value_Column_Id                  int
)
AS
	INSERT INTO [AS].[DataSources] (
		[ListName],
		[Object_Id],
		[Key_Column_Id],
		[Value_Column_Id]
) VALUES (
		@ListName,
		@Object_Id,
		@Key_Column_Id,
		@Value_Column_Id
)
	SELECT @Id= SCOPE_IDENTITY();