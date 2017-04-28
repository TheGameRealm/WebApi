#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // Items
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class ItemConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
            : this("dbo")
        {
        }

        public ItemConfiguration(string schema)
        {
            ToTable("Items", schema);
            HasKey(x => x.ItemId);

            Property(x => x.ItemId).HasColumnName(@"ItemId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
            Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar").IsOptional().HasMaxLength(256);
            Property(x => x.Weight).HasColumnName(@"Weight").HasColumnType("nchar").IsOptional().IsFixedLength().HasMaxLength(10);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
