CREATE TABLE [AT].[Languages] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)   NOT NULL,
    [CultureName] NCHAR (10)      NOT NULL,
    [Image]       VARBINARY (MAX) NULL,
    CONSTRAINT [PK__Language__3214EC074BCC3ABA] PRIMARY KEY CLUSTERED ([Id] ASC)
);

