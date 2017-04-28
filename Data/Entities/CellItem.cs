#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // CellItems
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class CellItem
    {
        public System.Guid CellItemId { get; set; } // CellItemId (Primary key)
        public System.Guid CellRefId { get; set; } // CellRefId
        public System.Guid ItemRefId { get; set; } // ItemRefId

        // Foreign keys
        public virtual Cell Cell { get; set; } // FK_CellItems_Cells
        public virtual Item Item { get; set; } // FK_CellItems_Items

        public CellItem()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
