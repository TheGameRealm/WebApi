CREATE TABLE [dbo].[Cells] (
    [CellId]            UNIQUEIDENTIFIER NOT NULL,
    [Description]       NVARCHAR (256)   NULL,
	[MapRefId]          UNIQUEIDENTIFIER NULL,
	[PathDescription]   NVARCHAR (MAX)   NULL,
    [LocationX]         INT              NOT NULL,
    [LocationY]         INT              NOT NULL,
    [Directions]        INT              NOT NULL,
    [PortalDirections] INT   NULL,
    [GotoMapRefId]      UNIQUEIDENTIFIER NULL,
    [GotoX]             INT              NULL,
    [GotoY]             INT              NULL,
    CONSTRAINT [PK_dbo.Cells] PRIMARY KEY CLUSTERED ([CellId] ASC),
    CONSTRAINT [FK_Cells_Maps] FOREIGN KEY ([MapRefId]) REFERENCES [dbo].[Maps] ([MapId]),
    CONSTRAINT [FK_Cells_Maps_Portal] FOREIGN KEY ([GotoMapRefId]) REFERENCES [dbo].[Maps] ([MapId])
);


GO
ALTER TABLE [dbo].[Cells] NOCHECK CONSTRAINT [FK_Cells_Maps_Portal];


GO
CREATE NONCLUSTERED INDEX [IX_Map_MapId]
    ON [dbo].[Cells]([MapRefId] ASC);

