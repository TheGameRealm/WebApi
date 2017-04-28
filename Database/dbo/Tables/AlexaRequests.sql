CREATE TABLE [dbo].[AlexaRequests] (
    [Id]            INT              IDENTITY (1, 1) NOT NULL,
    [RequestId]     NVARCHAR (256)   NULL,
    [SessionId]     NVARCHAR (256)   NULL,
    [UserId]        NVARCHAR (256)   NULL,
    [Timestamp]     DATETIME         NOT NULL,
    [Intent]        NVARCHAR (MAX)   NULL,
    [SlotsToString] NVARCHAR (256)   NULL,
    [IsNew]         BIT              NOT NULL,
    [Version]       NVARCHAR (10)    NULL,
    [Type]          NVARCHAR (50)    NULL,
    [DateCreated]   DATETIME         NOT NULL,
    [AccountRefId]  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_dbo.AlexaRequests] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AlexaRequests_dbo.AlexaAccounts_AccountRefId] FOREIGN KEY ([AccountRefId]) REFERENCES [dbo].[AlexaAccounts] ([AccountId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountRefId]
    ON [dbo].[AlexaRequests]([AccountRefId] ASC);

