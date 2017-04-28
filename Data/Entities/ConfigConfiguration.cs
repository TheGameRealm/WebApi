#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // Configs
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class ConfigConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Config>
    {
        public ConfigConfiguration()
            : this("dbo")
        {
        }

        public ConfigConfiguration(string schema)
        {
            ToTable("Configs", schema);
            HasKey(x => x.ConfigId);

            Property(x => x.ConfigId).HasColumnName(@"ConfigId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Key).HasColumnName(@"Key").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.Group).HasColumnName(@"Group").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.Value).HasColumnName(@"Value").HasColumnType("nvarchar").IsRequired().HasMaxLength(1024);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
