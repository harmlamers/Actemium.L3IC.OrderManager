
/* Retrieves one DataSource from the database using its primary key */
CREATE PROCEDURE [AS].[DataSourcesGennie_GetById] (
		@Id                               int
)
AS
	SELECT *
	FROM [AS].[DataSources]
	WHERE
		[DataSources].[Id] = @Id