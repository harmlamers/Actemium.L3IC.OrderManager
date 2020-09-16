CREATE TABLE [UM].[GroupAccessControlLists] (
    [AccessControlListId] INT NOT NULL,
    [GroupId]             INT NOT NULL,
    CONSTRAINT [PK_GroupAccessControlLists] PRIMARY KEY CLUSTERED ([AccessControlListId] ASC, [GroupId] ASC),
    CONSTRAINT [FK_GroupAccessControlLists_AccessControlItems] FOREIGN KEY ([AccessControlListId]) REFERENCES [UM].[AccessControlItems] ([Id]),
    CONSTRAINT [FK_GroupAccessControlLists_Groups] FOREIGN KEY ([GroupId]) REFERENCES [UM].[Groups] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_GroupAccessControlLists_Groups]
    ON [UM].[GroupAccessControlLists]([GroupId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_GroupAccessControlLists_AccessControlItems]
    ON [UM].[GroupAccessControlLists]([AccessControlListId] ASC);

