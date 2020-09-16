CREATE TABLE [AS].[DataSources] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [ListName]        VARCHAR (50) NOT NULL,
    [Object_Id]       INT          NOT NULL,
    [Key_Column_Id]   INT          NOT NULL,
    [Value_Column_Id] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([ListName] ASC)
);




GO
-- =============================================
-- Author:		Brian van der Horst BHT
-- Create date: 19-07-2019
-- Description:	Trigger to check the constraints of the insert/update in AS.DataSources
-- =============================================
CREATE TRIGGER [AS].CheckConstraintsDataSourcesTrigger
   ON  [AS].DataSources 
   AFTER INSERT, UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE 
		@Object_Id INT,
		@Key_Column_Id INT,
		@Value_Column_Id INT

    -- Insert statements for trigger here
	DECLARE insertedCursor CURSOR FOR   
	SELECT [Object_Id], [Key_Column_Id], [Value_Column_Id]
	FROM inserted  
  
	OPEN insertedCursor  
  
	FETCH NEXT FROM insertedCursor
	INTO @Object_Id, @Key_Column_Id, @Value_Column_Id
  
	WHILE @@FETCH_STATUS = 0  
	BEGIN  

		IF([AS].CheckListConstraint(@Object_Id, @Key_Column_Id, @Value_Column_Id) = 0)
		BEGIN
			RAISERROR('Input does not match constraint criteria', 18, 1)
			ROLLBACK TRANSACTION
		END


		FETCH NEXT FROM insertedCursor
		INTO @Object_Id, @Key_Column_Id, @Value_Column_Id
	END   
	CLOSE insertedCursor;  
	DEALLOCATE insertedCursor;  
END