#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // CellItems
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class CellItemConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CellItem>
    {
        public CellItemConfiguration()
            : this("dbo")
        {
        }

        public CellItemConfiguration(string schema)
        {
            ToTable("CellItems", schema);
            HasKey(x => x.CellItemId);

            Property(x => x.CellItemId).HasColumnName(@"CellItemId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.CellRefId).HasColumnName(@"CellRefId").HasColumnType("uniqueidentifier").IsRequired();
            Property(x => x.ItemRefId).HasColumnName(@"ItemRefId").HasColumnType("uniqueidentifier").IsRequired();

            // Foreign keys
            HasRequired(a => a.Cell).WithMany(b => b.CellItems).HasForeignKey(c => c.CellRefId).WillCascadeOnDelete(false); // FK_CellItems_Cells
            HasRequired(a => a.Item).WithMany(b => b.CellItems).HasForeignKey(c => c.ItemRefId).WillCascadeOnDelete(false); // FK_CellItems_Items
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
