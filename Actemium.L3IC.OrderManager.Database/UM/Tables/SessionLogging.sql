CREATE TABLE [UM].[SessionLogging] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [UserId]             INT           NOT NULL,
    [ComputerId]         INT           NOT NULL,
    [HostComputerName]   NVARCHAR (50) NOT NULL,
    [ClientComputerName] NVARCHAR (50) NOT NULL,
    [Starttime]          DATETIME      NOT NULL,
    [Endtime]            DATETIME      NULL,
    [LastActivity]       DATETIME      NOT NULL,
    CONSTRAINT [PK_SessionLogging] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SessionLogging_Computers] FOREIGN KEY ([ComputerId]) REFERENCES [UM].[Computers] ([Id]),
    CONSTRAINT [FK_SessionLogging_Users] FOREIGN KEY ([UserId]) REFERENCES [UM].[Users] ([Id])
);

