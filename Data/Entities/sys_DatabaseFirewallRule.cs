#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // database_firewall_rules
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class sys_DatabaseFirewallRule
    {
        public int Id { get; set; } // id (Primary key)
        public string Name { get; set; } // name (Primary key) (length: 128)
        public string StartIpAddress { get; set; } // start_ip_address (Primary key) (length: 45)
        public string EndIpAddress { get; set; } // end_ip_address (Primary key) (length: 45)
        public System.DateTime CreateDate { get; set; } // create_date (Primary key)
        public System.DateTime ModifyDate { get; set; } // modify_date (Primary key)

        public sys_DatabaseFirewallRule()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
