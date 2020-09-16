CREATE TABLE [UM].[UserAccessControlLists] (
    [AccessControlListId] INT NOT NULL,
    [UserId]              INT NOT NULL,
    CONSTRAINT [PK_UserAccessControlLists] PRIMARY KEY CLUSTERED ([AccessControlListId] ASC, [UserId] ASC),
    CONSTRAINT [FK_UserAccessControlLists_AccessControlItems] FOREIGN KEY ([AccessControlListId]) REFERENCES [UM].[AccessControlItems] ([Id]),
    CONSTRAINT [FK_UserAccessControlLists_Users] FOREIGN KEY ([UserId]) REFERENCES [UM].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserAccessControlLists_Users]
    ON [UM].[UserAccessControlLists]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserAccessControlLists_AccessControlItems]
    ON [UM].[UserAccessControlLists]([AccessControlListId] ASC);

