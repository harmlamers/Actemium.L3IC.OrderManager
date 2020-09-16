CREATE TABLE [UM].[AccessControlItems] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Category] NVARCHAR (50) NOT NULL,
    [Action]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_AccessControlItems] PRIMARY KEY CLUSTERED ([Id] ASC)
);

