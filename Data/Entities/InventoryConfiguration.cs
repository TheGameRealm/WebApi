#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // Inventory
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class InventoryConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Inventory>
    {
        public InventoryConfiguration()
            : this("dbo")
        {
        }

        public InventoryConfiguration(string schema)
        {
            ToTable("Inventory", schema);
            HasKey(x => x.InventoryId);

            Property(x => x.InventoryId).HasColumnName(@"InventoryId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.PlayerRefId).HasColumnName(@"PlayerRefId").HasColumnType("uniqueidentifier").IsRequired();
            Property(x => x.ItemRefId).HasColumnName(@"ItemRefId").HasColumnType("uniqueidentifier").IsRequired();

            // Foreign keys
            HasRequired(a => a.Item).WithMany(b => b.Inventories).HasForeignKey(c => c.ItemRefId).WillCascadeOnDelete(false); // FK_Inventory_Items
            HasRequired(a => a.Player).WithMany(b => b.Inventories).HasForeignKey(c => c.PlayerRefId).WillCascadeOnDelete(false); // FK_Inventory_Players
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
