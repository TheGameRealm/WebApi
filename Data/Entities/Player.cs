#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // Players
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class Player
    {
        public System.Guid PlayerId { get; set; } // PlayerId (Primary key)
        public string Name { get; set; } // Name (length: 50)
        public System.Guid MapRefId { get; set; } // MapRefId
        public int LocationX { get; set; } // LocationX
        public int LocationY { get; set; } // LocationY
        public int Level { get; set; } // Level
        public int Gold { get; set; } // Gold
        public int Toughness { get; set; } // Toughness
        public int Energy { get; set; } // Energy
        public System.Guid AccountRefId { get; set; } // AccountRefId
        public int Verbosity { get; set; } // Verbosity

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<Inventory> Inventories { get; set; } // Inventory.FK_Inventory_Players

        public Player()
        {
            Verbosity = 7;
            Inventories = new System.Collections.Generic.List<Inventory>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
