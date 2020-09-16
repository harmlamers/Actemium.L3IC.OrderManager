CREATE TABLE [UM].[Users] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Username]    NVARCHAR (50)  NULL,
    [Password]    NVARCHAR (200) NULL,
    [Name]        NVARCHAR (25)  NULL,
    [SurName]     NVARCHAR (25)  NULL,
    [AccountType] INT            NOT NULL,
    [IsActive]    BIT            NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

