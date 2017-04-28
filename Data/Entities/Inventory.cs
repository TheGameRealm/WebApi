#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // Inventory
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class Inventory
    {
        public System.Guid InventoryId { get; set; } // InventoryId (Primary key)
        public System.Guid PlayerRefId { get; set; } // PlayerRefId
        public System.Guid ItemRefId { get; set; } // ItemRefId

        // Foreign keys
        public virtual Item Item { get; set; } // FK_Inventory_Items
        public virtual Player Player { get; set; } // FK_Inventory_Players

        public Inventory()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
