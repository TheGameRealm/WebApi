CREATE TABLE [dbo].[CellItems] (
    [CellItemId] UNIQUEIDENTIFIER NOT NULL,
    [CellRefId]  UNIQUEIDENTIFIER NOT NULL,
    [ItemRefId]  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_CellItems] PRIMARY KEY CLUSTERED ([CellItemId] ASC),
    CONSTRAINT [FK_CellItems_Cells] FOREIGN KEY ([CellRefId]) REFERENCES [dbo].[Cells] ([CellId]),
    CONSTRAINT [FK_CellItems_Items] FOREIGN KEY ([ItemRefId]) REFERENCES [dbo].[Items] ([ItemId])
);

