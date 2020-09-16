CREATE TABLE [HIST].[HistoryActions] (
    [HistoryActionId] BIGINT         IDENTITY (1, 1) NOT NULL,
    [HistoryKey]      NVARCHAR (100) NOT NULL,
    [TimeStampUTC]    DATETIME       NOT NULL,
    [UserId]          INT            NULL,
    [ComputerId]      INT            NULL,
    [Parameters]      XML            NULL,
    CONSTRAINT [PK_HistoryActions] PRIMARY KEY CLUSTERED ([HistoryActionId] ASC),
    CONSTRAINT [FK_HistoryActions_Computers] FOREIGN KEY ([ComputerId]) REFERENCES [UM].[Computers] ([Id]),
    CONSTRAINT [FK_HistoryActions_HistoryKeys] FOREIGN KEY ([HistoryKey]) REFERENCES [HIST].[HistoryKeys] ([HistoryKey]),
    CONSTRAINT [FK_HistoryActions_Users] FOREIGN KEY ([UserId]) REFERENCES [UM].[Users] ([Id])
);

