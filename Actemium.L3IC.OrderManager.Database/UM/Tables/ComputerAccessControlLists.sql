CREATE TABLE [UM].[ComputerAccessControlLists] (
    [AccessControlListId] INT NOT NULL,
    [ComputerId]          INT NOT NULL,
    CONSTRAINT [PK_ComputerAccessControlLists] PRIMARY KEY CLUSTERED ([AccessControlListId] ASC, [ComputerId] ASC),
    CONSTRAINT [FK_ComputerAccessControlLists_AccessControlItems] FOREIGN KEY ([AccessControlListId]) REFERENCES [UM].[AccessControlItems] ([Id]),
    CONSTRAINT [FK_ComputerAccessControlLists_Computers] FOREIGN KEY ([ComputerId]) REFERENCES [UM].[Computers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ComputerAccessControlLists_Computers]
    ON [UM].[ComputerAccessControlLists]([ComputerId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ComputerAccessControlLists_AccessControlItems]
    ON [UM].[ComputerAccessControlLists]([AccessControlListId] ASC);

