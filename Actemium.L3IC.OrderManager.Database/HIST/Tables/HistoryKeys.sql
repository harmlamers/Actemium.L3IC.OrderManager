CREATE TABLE [HIST].[HistoryKeys] (
    [HistoryKey]     NVARCHAR (100) NOT NULL,
    [ShowInClient]   BIT            CONSTRAINT [DF_HistoryKeys_ShowInClient] DEFAULT ((1)) NOT NULL,
    [SaveInDatabase] BIT            CONSTRAINT [DF_HistoryKeys_SaveInDatabase] DEFAULT ((0)) NOT NULL,
    [TraceLevel]     NVARCHAR (100) CONSTRAINT [DF_HistoryKeys_TraceLevel] DEFAULT (N'Verbose') NOT NULL,
    CONSTRAINT [PK_HistoryKeys] PRIMARY KEY CLUSTERED ([HistoryKey] ASC),
    CONSTRAINT [CK_HistoryKeys_TraceLevel] CHECK ([TraceLevel]='Critical' OR [TraceLevel]='Off' OR [TraceLevel]='Error' OR [TraceLevel]='Warning' OR [TraceLevel]='Information' OR [TraceLevel]='Verbose')
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'System.Diagnostics.SourceLevels excluding ActivityTracing and All', @level0type = N'SCHEMA', @level0name = N'HIST', @level1type = N'TABLE', @level1name = N'HistoryKeys', @level2type = N'CONSTRAINT', @level2name = N'CK_HistoryKeys_TraceLevel';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'System.Diagnostics.SourceLevels excluding ActivityTracing and All', @level0type = N'SCHEMA', @level0name = N'HIST', @level1type = N'TABLE', @level1name = N'HistoryKeys', @level2type = N'COLUMN', @level2name = N'TraceLevel';

