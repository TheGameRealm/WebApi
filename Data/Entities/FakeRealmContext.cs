#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    using System.Linq;

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class FakeRealmContext : IRealmContext
    {
        public System.Data.Entity.DbSet<AlexaAccount> AlexaAccounts { get; set; }
        public System.Data.Entity.DbSet<AlexaRequest> AlexaRequests { get; set; }
        public System.Data.Entity.DbSet<Cell> Cells { get; set; }
        public System.Data.Entity.DbSet<CellItem> CellItems { get; set; }
        public System.Data.Entity.DbSet<Config> Configs { get; set; }
        public System.Data.Entity.DbSet<Inventory> Inventories { get; set; }
        public System.Data.Entity.DbSet<Item> Items { get; set; }
        public System.Data.Entity.DbSet<Log> Logs { get; set; }
        public System.Data.Entity.DbSet<Map> Maps { get; set; }
        public System.Data.Entity.DbSet<Player> Players { get; set; }
        public System.Data.Entity.DbSet<RefactorLog> RefactorLogs { get; set; }
        public System.Data.Entity.DbSet<sys_DatabaseFirewallRule> sys_DatabaseFirewallRules { get; set; }

        public FakeRealmContext()
        {
            AlexaAccounts = new FakeDbSet<AlexaAccount>("AccountId");
            AlexaRequests = new FakeDbSet<AlexaRequest>("Id");
            Cells = new FakeDbSet<Cell>("CellId");
            CellItems = new FakeDbSet<CellItem>("CellItemId");
            Configs = new FakeDbSet<Config>("ConfigId");
            Inventories = new FakeDbSet<Inventory>("InventoryId");
            Items = new FakeDbSet<Item>("ItemId");
            Logs = new FakeDbSet<Log>("LogId");
            Maps = new FakeDbSet<Map>("MapId");
            Players = new FakeDbSet<Player>("PlayerId");
            RefactorLogs = new FakeDbSet<RefactorLog>("OperationKey");
            sys_DatabaseFirewallRules = new FakeDbSet<sys_DatabaseFirewallRule>("Id", "Name", "StartIpAddress", "EndIpAddress", "CreateDate", "ModifyDate");

            InitializePartial();
        }

        public int SaveChangesCount { get; private set; }
        public int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1);
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1, cancellationToken);
        }

        partial void InitializePartial();

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public System.Data.Entity.Infrastructure.DbChangeTracker _changeTracker;
        public System.Data.Entity.Infrastructure.DbChangeTracker ChangeTracker { get { return _changeTracker; } }
        public System.Data.Entity.Infrastructure.DbContextConfiguration _configuration;
        public System.Data.Entity.Infrastructure.DbContextConfiguration Configuration { get { return _configuration; } }
        public System.Data.Entity.Database _database;
        public System.Data.Entity.Database Database { get { return _database; } }
        public System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new System.NotImplementedException();
        }
        public System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity)
        {
            throw new System.NotImplementedException();
        }
        public System.Collections.Generic.IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> GetValidationErrors()
        {
            throw new System.NotImplementedException();
        }
        public System.Data.Entity.DbSet Set(System.Type entityType)
        {
            throw new System.NotImplementedException();
        }
        public System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            throw new System.NotImplementedException();
        }

    }
}
