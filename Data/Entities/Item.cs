#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // Items
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class Item
    {
        public System.Guid ItemId { get; set; } // ItemId (Primary key)
        public string Name { get; set; } // Name (length: 128)
        public string Description { get; set; } // Description (length: 256)
        public string Weight { get; set; } // Weight (length: 10)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<CellItem> CellItems { get; set; } // CellItems.FK_CellItems_Items
        public virtual System.Collections.Generic.ICollection<Inventory> Inventories { get; set; } // Inventory.FK_Inventory_Items

        public Item()
        {
            CellItems = new System.Collections.Generic.List<CellItem>();
            Inventories = new System.Collections.Generic.List<Inventory>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
