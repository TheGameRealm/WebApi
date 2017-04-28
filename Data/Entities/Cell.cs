#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // Cells
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class Cell
    {
        public System.Guid CellId { get; set; } // CellId (Primary key)
        public string Description { get; set; } // Description (length: 256)
        public int LocationX { get; set; } // LocationX
        public int LocationY { get; set; } // LocationY
        public int Directions { get; set; } // Directions
        public string PathDescription { get; set; } // PathDescription
        public int? PortalDirections { get; set; } // PortalDirections
        public System.Guid? GotoMapRefId { get; set; } // GotoMapRefId
        public int? GotoX { get; set; } // GotoX
        public int? GotoY { get; set; } // GotoY
        public System.Guid? MapRefId { get; set; } // MapRefId

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<CellItem> CellItems { get; set; } // CellItems.FK_CellItems_Cells

        // Foreign keys
        public virtual Map GotoMapRef { get; set; } // FK_Cells_Maps_Portal
        public virtual Map MapRef { get; set; } // FK_Cells_Maps

        public Cell()
        {
            CellItems = new System.Collections.Generic.List<CellItem>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
