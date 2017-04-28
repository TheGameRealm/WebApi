CREATE TABLE [dbo].[AlexaAccounts] (
    [AccountId]    UNIQUEIDENTIFIER NOT NULL,
    [AlexaUserId]  NVARCHAR (256)   NULL,
    [DateCreated]  DATETIME         NOT NULL,
    [LastRequest]  DATETIME         NOT NULL,
    [RequestCount] INT              NOT NULL,
    CONSTRAINT [PK_dbo.AlexaAccounts] PRIMARY KEY CLUSTERED ([AccountId] ASC)
);

