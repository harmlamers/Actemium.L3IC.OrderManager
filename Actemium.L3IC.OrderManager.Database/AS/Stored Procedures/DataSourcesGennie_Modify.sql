

/* Modifies an DataSource in the database */
CREATE PROCEDURE [AS].[DataSourcesGennie_Modify] (
		@Id                               int,
		@ListName                         varchar(50),
		@Object_Id                        int,
		@Key_Column_Id                    int,
		@Value_Column_Id                  int
)
AS
	UPDATE [AS].[DataSources] SET
		[DataSources].[ListName] = @ListName, 
		[DataSources].[Object_Id] = @Object_Id, 
		[DataSources].[Key_Column_Id] = @Key_Column_Id, 
		[DataSources].[Value_Column_Id] = @Value_Column_Id
	WHERE
		[DataSources].[Id] = @Id