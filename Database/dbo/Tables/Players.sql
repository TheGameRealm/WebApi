CREATE TABLE [dbo].[Players] (
    [PlayerId]     UNIQUEIDENTIFIER NOT NULL,
    [Name]         NVARCHAR (50)    NOT NULL,
    [MapRefId]     UNIQUEIDENTIFIER NOT NULL,
    [LocationX]    INT              NOT NULL,
    [LocationY]    INT              NOT NULL,
    [Level]        INT              NOT NULL,
    [Gold]         INT              NOT NULL,
    [Toughness]    INT              NOT NULL,
    [Energy]       INT              NOT NULL,
    [AccountRefId] UNIQUEIDENTIFIER NOT NULL,
    [Verbosity] INT NOT NULL DEFAULT 7, 
    CONSTRAINT [PK_dbo.Players] PRIMARY KEY CLUSTERED ([PlayerId] ASC),
    CONSTRAINT [FK_Players_AlexaAccounts] FOREIGN KEY ([AccountRefId]) REFERENCES [dbo].[AlexaAccounts] ([AccountId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Players_Maps] FOREIGN KEY ([MapRefId]) REFERENCES [dbo].[Maps] ([MapId])
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountRefId]
    ON [dbo].[Players]([AccountRefId] ASC);

