CREATE TABLE [UM].[Computers] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [HostName]    NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (255) NULL,
    [ACIManaged]  BIT            NOT NULL,
    CONSTRAINT [PK_Computers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

