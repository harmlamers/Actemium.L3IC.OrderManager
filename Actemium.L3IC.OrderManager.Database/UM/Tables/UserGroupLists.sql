CREATE TABLE [UM].[UserGroupLists] (
    [UserId]  INT NOT NULL,
    [GroupId] INT NOT NULL,
    CONSTRAINT [PK_UserGroupLists] PRIMARY KEY CLUSTERED ([UserId] ASC, [GroupId] ASC),
    CONSTRAINT [FK_UserGroupLists_Groups] FOREIGN KEY ([GroupId]) REFERENCES [UM].[Groups] ([Id]),
    CONSTRAINT [FK_UserGroupLists_Users] FOREIGN KEY ([UserId]) REFERENCES [UM].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserGroupLists_Users]
    ON [UM].[UserGroupLists]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserGroupLists_Groups]
    ON [UM].[UserGroupLists]([GroupId] ASC);

