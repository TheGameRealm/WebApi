#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // AlexaAccounts
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class AlexaAccountConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AlexaAccount>
    {
        public AlexaAccountConfiguration()
            : this("dbo")
        {
        }

        public AlexaAccountConfiguration(string schema)
        {
            ToTable("AlexaAccounts", schema);
            HasKey(x => x.AccountId);

            Property(x => x.AccountId).HasColumnName(@"AccountId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.AlexaUserId).HasColumnName(@"AlexaUserId").HasColumnType("nvarchar").IsOptional().HasMaxLength(256);
            Property(x => x.DateCreated).HasColumnName(@"DateCreated").HasColumnType("datetime").IsRequired();
            Property(x => x.LastRequest).HasColumnName(@"LastRequest").HasColumnType("datetime").IsRequired();
            Property(x => x.RequestCount).HasColumnName(@"RequestCount").HasColumnType("int").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
