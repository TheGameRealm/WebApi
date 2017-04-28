CREATE TABLE [dbo].[Inventory] (
    [InventoryId] UNIQUEIDENTIFIER NOT NULL,
    [PlayerRefId] UNIQUEIDENTIFIER NOT NULL,
    [ItemRefId]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED ([InventoryId] ASC),
    CONSTRAINT [FK_Inventory_Items] FOREIGN KEY ([ItemRefId]) REFERENCES [dbo].[Items] ([ItemId]),
    CONSTRAINT [FK_Inventory_Players] FOREIGN KEY ([PlayerRefId]) REFERENCES [dbo].[Players] ([PlayerId])
);

