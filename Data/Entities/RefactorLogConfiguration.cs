#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // __RefactorLog
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class RefactorLogConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<RefactorLog>
    {
        public RefactorLogConfiguration()
            : this("dbo")
        {
        }

        public RefactorLogConfiguration(string schema)
        {
            ToTable("__RefactorLog", schema);
            HasKey(x => x.OperationKey);

            Property(x => x.OperationKey).HasColumnName(@"OperationKey").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
