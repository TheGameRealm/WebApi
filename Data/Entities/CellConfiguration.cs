#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // Cells
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class CellConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Cell>
    {
        public CellConfiguration()
            : this("dbo")
        {
        }

        public CellConfiguration(string schema)
        {
            ToTable("Cells", schema);
            HasKey(x => x.CellId);

            Property(x => x.CellId).HasColumnName(@"CellId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar").IsOptional().HasMaxLength(256);
            Property(x => x.LocationX).HasColumnName(@"LocationX").HasColumnType("int").IsRequired();
            Property(x => x.LocationY).HasColumnName(@"LocationY").HasColumnType("int").IsRequired();
            Property(x => x.Directions).HasColumnName(@"Directions").HasColumnType("int").IsRequired();
            Property(x => x.PathDescription).HasColumnName(@"PathDescription").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.PortalDirections).HasColumnName(@"PortalDirections").HasColumnType("int").IsOptional();
            Property(x => x.GotoMapRefId).HasColumnName(@"GotoMapRefId").HasColumnType("uniqueidentifier").IsOptional();
            Property(x => x.GotoX).HasColumnName(@"GotoX").HasColumnType("int").IsOptional();
            Property(x => x.GotoY).HasColumnName(@"GotoY").HasColumnType("int").IsOptional();
            Property(x => x.MapRefId).HasColumnName(@"MapRefId").HasColumnType("uniqueidentifier").IsOptional();

            // Foreign keys
            HasOptional(a => a.GotoMapRef).WithMany(b => b.GotoMapRef).HasForeignKey(c => c.GotoMapRefId).WillCascadeOnDelete(false); // FK_Cells_Maps_Portal
            HasOptional(a => a.MapRef).WithMany(b => b.MapRef).HasForeignKey(c => c.MapRefId).WillCascadeOnDelete(false); // FK_Cells_Maps
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
