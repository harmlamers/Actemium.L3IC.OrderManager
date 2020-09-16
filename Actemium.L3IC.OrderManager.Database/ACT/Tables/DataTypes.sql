CREATE TABLE [ACT].[DataTypes] (
    [DataTypeId]  INT            NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (100) NULL,
    CONSTRAINT [PK_DataTypes] PRIMARY KEY CLUSTERED ([DataTypeId] ASC)
);

