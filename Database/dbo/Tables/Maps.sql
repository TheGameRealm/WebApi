CREATE TABLE [dbo].[Maps] (
    [MapId]       UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (128)   NOT NULL,
    [Description] NVARCHAR (256)   NULL,
    [Level]       INT              NOT NULL,
    CONSTRAINT [PK_dbo.Maps] PRIMARY KEY CLUSTERED ([MapId] ASC)
);

