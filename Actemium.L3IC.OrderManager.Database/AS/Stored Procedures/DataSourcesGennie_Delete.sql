
/* Deletes a DataSource from the database */
CREATE PROCEDURE [AS].[DataSourcesGennie_Delete] (
		@Id                               int
)
AS
	DELETE FROM [AS].[DataSources] WHERE (
		[Id] = @Id
)