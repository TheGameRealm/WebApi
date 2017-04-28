#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // database_firewall_rules
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class sys_DatabaseFirewallRuleConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<sys_DatabaseFirewallRule>
    {
        public sys_DatabaseFirewallRuleConfiguration()
            : this("sys")
        {
        }

        public sys_DatabaseFirewallRuleConfiguration(string schema)
        {
            ToTable("database_firewall_rules", schema);
            HasKey(x => new { x.Id, x.Name, x.StartIpAddress, x.EndIpAddress, x.CreateDate, x.ModifyDate });

            Property(x => x.Id).HasColumnName(@"id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName(@"name").HasColumnType("nvarchar").IsRequired().HasMaxLength(128).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.StartIpAddress).HasColumnName(@"start_ip_address").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(45).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.EndIpAddress).HasColumnName(@"end_ip_address").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(45).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.CreateDate).HasColumnName(@"create_date").HasColumnType("datetime").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.ModifyDate).HasColumnName(@"modify_date").HasColumnType("datetime").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
