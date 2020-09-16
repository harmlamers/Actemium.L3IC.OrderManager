CREATE TABLE [UM].[GroupPropertyValues] (
    [PropertyId] INT            NOT NULL,
    [GroupId]    INT            NOT NULL,
    [Value]      NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_GroupPropertyValues] PRIMARY KEY CLUSTERED ([PropertyId] ASC, [GroupId] ASC),
    CONSTRAINT [FK_GroupPropertyValues_Groups] FOREIGN KEY ([GroupId]) REFERENCES [UM].[Groups] ([Id]),
    CONSTRAINT [FK_GroupPropertyValues_Properties] FOREIGN KEY ([PropertyId]) REFERENCES [UM].[Properties] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_GroupPropertyValues_Properties]
    ON [UM].[GroupPropertyValues]([PropertyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_GroupPropertyValues_Groups]
    ON [UM].[GroupPropertyValues]([GroupId] ASC);

