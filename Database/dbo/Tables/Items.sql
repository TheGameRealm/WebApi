CREATE TABLE [dbo].[Items] (
    [ItemId]      UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (128)   NOT NULL,
    [Description] NVARCHAR (256)   NULL,
    [Weight]      NCHAR (10)       NULL,
    CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED ([ItemId] ASC)
);

