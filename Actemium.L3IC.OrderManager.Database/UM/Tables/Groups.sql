CREATE TABLE [UM].[Groups] (
    [Id]                    INT            IDENTITY (1, 1) NOT NULL,
    [Name]                  NVARCHAR (50)  NOT NULL,
    [Description]           NVARCHAR (255) NULL,
    [DomainGroupIdentifier] NVARCHAR (255) NULL,
    CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED ([Id] ASC)
);

