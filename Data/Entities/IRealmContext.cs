#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    public interface IRealmContext : System.IDisposable
    {
        System.Data.Entity.DbSet<AlexaAccount> AlexaAccounts { get; set; } // AlexaAccounts
        System.Data.Entity.DbSet<AlexaRequest> AlexaRequests { get; set; } // AlexaRequests
        System.Data.Entity.DbSet<Cell> Cells { get; set; } // Cells
        System.Data.Entity.DbSet<CellItem> CellItems { get; set; } // CellItems
        System.Data.Entity.DbSet<Config> Configs { get; set; } // Configs
        System.Data.Entity.DbSet<Inventory> Inventories { get; set; } // Inventory
        System.Data.Entity.DbSet<Item> Items { get; set; } // Items
        System.Data.Entity.DbSet<Log> Logs { get; set; } // Log
        System.Data.Entity.DbSet<Map> Maps { get; set; } // Maps
        System.Data.Entity.DbSet<Player> Players { get; set; } // Players
        System.Data.Entity.DbSet<RefactorLog> RefactorLogs { get; set; } // __RefactorLog
        System.Data.Entity.DbSet<sys_DatabaseFirewallRule> sys_DatabaseFirewallRules { get; set; } // database_firewall_rules

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);
        System.Data.Entity.Infrastructure.DbChangeTracker ChangeTracker { get; }
        System.Data.Entity.Infrastructure.DbContextConfiguration Configuration { get; }
        System.Data.Entity.Database Database { get; }
        System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity);
        System.Collections.Generic.IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> GetValidationErrors();
        System.Data.Entity.DbSet Set(System.Type entityType);
        System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();
    }

}
