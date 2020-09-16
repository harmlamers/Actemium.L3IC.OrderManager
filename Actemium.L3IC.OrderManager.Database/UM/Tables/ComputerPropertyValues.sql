CREATE TABLE [UM].[ComputerPropertyValues] (
    [PropertyId] INT            NOT NULL,
    [ComputerId] INT            NOT NULL,
    [Value]      NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_ComputerPropertyValues] PRIMARY KEY CLUSTERED ([PropertyId] ASC, [ComputerId] ASC),
    CONSTRAINT [FK_ComputerPropertyValues_Computers] FOREIGN KEY ([ComputerId]) REFERENCES [UM].[Computers] ([Id]),
    CONSTRAINT [FK_ComputerPropertyValues_Properties] FOREIGN KEY ([PropertyId]) REFERENCES [UM].[Properties] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ComputerPropertyValues_Properties]
    ON [UM].[ComputerPropertyValues]([PropertyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ComputerPropertyValues_Computers]
    ON [UM].[ComputerPropertyValues]([ComputerId] ASC);

