#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // Players
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class PlayerConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Player>
    {
        public PlayerConfiguration()
            : this("dbo")
        {
        }

        public PlayerConfiguration(string schema)
        {
            ToTable("Players", schema);
            HasKey(x => x.PlayerId);

            Property(x => x.PlayerId).HasColumnName(@"PlayerId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.MapRefId).HasColumnName(@"MapRefId").HasColumnType("uniqueidentifier").IsRequired();
            Property(x => x.LocationX).HasColumnName(@"LocationX").HasColumnType("int").IsRequired();
            Property(x => x.LocationY).HasColumnName(@"LocationY").HasColumnType("int").IsRequired();
            Property(x => x.Level).HasColumnName(@"Level").HasColumnType("int").IsRequired();
            Property(x => x.Gold).HasColumnName(@"Gold").HasColumnType("int").IsRequired();
            Property(x => x.Toughness).HasColumnName(@"Toughness").HasColumnType("int").IsRequired();
            Property(x => x.Energy).HasColumnName(@"Energy").HasColumnType("int").IsRequired();
            Property(x => x.AccountRefId).HasColumnName(@"AccountRefId").HasColumnType("uniqueidentifier").IsRequired();
            Property(x => x.Verbosity).HasColumnName(@"Verbosity").HasColumnType("int").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
