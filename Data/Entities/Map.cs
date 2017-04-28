#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // Maps
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class Map
    {
        public System.Guid MapId { get; set; } // MapId (Primary key)
        public string Name { get; set; } // Name (length: 128)
        public string Description { get; set; } // Description (length: 256)
        public int Level { get; set; } // Level

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<Cell> GotoMapRef { get; set; } // Cells.FK_Cells_Maps_Portal
        public virtual System.Collections.Generic.ICollection<Cell> MapRef { get; set; } // Cells.FK_Cells_Maps

        public Map()
        {
            GotoMapRef = new System.Collections.Generic.List<Cell>();
            MapRef = new System.Collections.Generic.List<Cell>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
