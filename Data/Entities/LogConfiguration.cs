#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // Log
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class LogConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Log>
    {
        public LogConfiguration()
            : this("dbo")
        {
        }

        public LogConfiguration(string schema)
        {
            ToTable("Log", schema);
            HasKey(x => x.LogId);

            Property(x => x.LogId).HasColumnName(@"LogId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Level).HasColumnName(@"Level").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.Logger).HasColumnName(@"Logger").HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
            Property(x => x.ThreadId).HasColumnName(@"ThreadId").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.Exception).HasColumnName(@"Exception").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.Content).HasColumnName(@"Content").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.StackTrace).HasColumnName(@"StackTrace").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.DateCreated).HasColumnName(@"Date_Created").HasColumnType("datetime2").IsRequired();
            Property(x => x.UserCreated).HasColumnName(@"User_Created").HasColumnType("uniqueidentifier").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
