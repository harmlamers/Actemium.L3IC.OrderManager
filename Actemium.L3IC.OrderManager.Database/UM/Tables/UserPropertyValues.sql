CREATE TABLE [UM].[UserPropertyValues] (
    [PropertyId] INT            NOT NULL,
    [UserId]     INT            NOT NULL,
    [Value]      NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_UserPropertyValues] PRIMARY KEY CLUSTERED ([PropertyId] ASC, [UserId] ASC),
    CONSTRAINT [FK_UserPropertyValues_Properties] FOREIGN KEY ([PropertyId]) REFERENCES [UM].[Properties] ([Id]),
    CONSTRAINT [FK_UserPropertyValues_Users] FOREIGN KEY ([UserId]) REFERENCES [UM].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserPropertyValues_Properties]
    ON [UM].[UserPropertyValues]([PropertyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserPropertyValues_Users]
    ON [UM].[UserPropertyValues]([UserId] ASC);

