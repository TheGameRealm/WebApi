#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // AlexaRequests
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class AlexaRequestConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AlexaRequest>
    {
        public AlexaRequestConfiguration()
            : this("dbo")
        {
        }

        public AlexaRequestConfiguration(string schema)
        {
            ToTable("AlexaRequests", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.RequestId).HasColumnName(@"RequestId").HasColumnType("nvarchar").IsOptional().HasMaxLength(256);
            Property(x => x.SessionId).HasColumnName(@"SessionId").HasColumnType("nvarchar").IsOptional().HasMaxLength(256);
            Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("nvarchar").IsOptional().HasMaxLength(256);
            Property(x => x.Timestamp).HasColumnName(@"Timestamp").HasColumnType("datetime").IsRequired();
            Property(x => x.Intent).HasColumnName(@"Intent").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.SlotsToString).HasColumnName(@"SlotsToString").HasColumnType("nvarchar").IsOptional().HasMaxLength(256);
            Property(x => x.IsNew).HasColumnName(@"IsNew").HasColumnType("bit").IsRequired();
            Property(x => x.Version).HasColumnName(@"Version").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);
            Property(x => x.Type).HasColumnName(@"Type").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.DateCreated).HasColumnName(@"DateCreated").HasColumnType("datetime").IsRequired();
            Property(x => x.AccountRefId).HasColumnName(@"AccountRefId").HasColumnType("uniqueidentifier").IsRequired();

            // Foreign keys
            HasRequired(a => a.AlexaAccount).WithMany(b => b.AlexaRequests).HasForeignKey(c => c.AccountRefId); // FK_dbo.AlexaRequests_dbo.AlexaAccounts_AccountRefId
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
