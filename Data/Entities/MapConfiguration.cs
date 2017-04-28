#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // Maps
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class MapConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Map>
    {
        public MapConfiguration()
            : this("dbo")
        {
        }

        public MapConfiguration(string schema)
        {
            ToTable("Maps", schema);
            HasKey(x => x.MapId);

            Property(x => x.MapId).HasColumnName(@"MapId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
            Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar").IsOptional().HasMaxLength(256);
            Property(x => x.Level).HasColumnName(@"Level").HasColumnType("int").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
