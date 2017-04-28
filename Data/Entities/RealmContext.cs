#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    using System.Linq;

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class RealmContext : System.Data.Entity.DbContext, IRealmContext
    {
        public System.Data.Entity.DbSet<AlexaAccount> AlexaAccounts { get; set; } // AlexaAccounts
        public System.Data.Entity.DbSet<AlexaRequest> AlexaRequests { get; set; } // AlexaRequests
        public System.Data.Entity.DbSet<Cell> Cells { get; set; } // Cells
        public System.Data.Entity.DbSet<CellItem> CellItems { get; set; } // CellItems
        public System.Data.Entity.DbSet<Config> Configs { get; set; } // Configs
        public System.Data.Entity.DbSet<Inventory> Inventories { get; set; } // Inventory
        public System.Data.Entity.DbSet<Item> Items { get; set; } // Items
        public System.Data.Entity.DbSet<Log> Logs { get; set; } // Log
        public System.Data.Entity.DbSet<Map> Maps { get; set; } // Maps
        public System.Data.Entity.DbSet<Player> Players { get; set; } // Players
        public System.Data.Entity.DbSet<RefactorLog> RefactorLogs { get; set; } // __RefactorLog
        public System.Data.Entity.DbSet<sys_DatabaseFirewallRule> sys_DatabaseFirewallRules { get; set; } // database_firewall_rules

        static RealmContext()
        {
            System.Data.Entity.Database.SetInitializer<RealmContext>(null);
            RealmContextStaticPartial(); // Create the following method in your partial class: private static void RealmContextStaticPartial() { }
        }

        public RealmContext()
            : base("Name=DefaultConnection")
        {
            InitializePartial();
        }

        public RealmContext(string connectionString)
            : base(connectionString)
        {
            InitializePartial();
        }

        public RealmContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
            InitializePartial();
        }

        public RealmContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            InitializePartial();
        }

        public RealmContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
            InitializePartial();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AlexaAccountConfiguration());
            modelBuilder.Configurations.Add(new AlexaRequestConfiguration());
            modelBuilder.Configurations.Add(new CellConfiguration());
            modelBuilder.Configurations.Add(new CellItemConfiguration());
            modelBuilder.Configurations.Add(new ConfigConfiguration());
            modelBuilder.Configurations.Add(new InventoryConfiguration());
            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new LogConfiguration());
            modelBuilder.Configurations.Add(new MapConfiguration());
            modelBuilder.Configurations.Add(new PlayerConfiguration());
            modelBuilder.Configurations.Add(new RefactorLogConfiguration());
            modelBuilder.Configurations.Add(new sys_DatabaseFirewallRuleConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AlexaAccountConfiguration(schema));
            modelBuilder.Configurations.Add(new AlexaRequestConfiguration(schema));
            modelBuilder.Configurations.Add(new CellConfiguration(schema));
            modelBuilder.Configurations.Add(new CellItemConfiguration(schema));
            modelBuilder.Configurations.Add(new ConfigConfiguration(schema));
            modelBuilder.Configurations.Add(new InventoryConfiguration(schema));
            modelBuilder.Configurations.Add(new ItemConfiguration(schema));
            modelBuilder.Configurations.Add(new LogConfiguration(schema));
            modelBuilder.Configurations.Add(new MapConfiguration(schema));
            modelBuilder.Configurations.Add(new PlayerConfiguration(schema));
            modelBuilder.Configurations.Add(new RefactorLogConfiguration(schema));
            modelBuilder.Configurations.Add(new sys_DatabaseFirewallRuleConfiguration(schema));
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void OnModelCreatingPartial(System.Data.Entity.DbModelBuilder modelBuilder);
    }
}
