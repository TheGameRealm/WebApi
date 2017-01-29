using Data.Entities;
using Data.Entities.Alexa;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class RealmContext : DbContext
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public RealmContext() : base("DefaultConnection")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<RealmContext>());
            Database.SetInitializer(new DatabaseInitializer());
            Database.Log = sqlString => logger.Trace(sqlString);
        } 

        public DbSet<Map> Maps { get; set; }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Player> Players { get; set; }

        public DbSet<AlexaMember> AlexaMembers { get; set; }
        public DbSet<AlexaRequest> AlexaRequests { get; set; }
        
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set;  }

    }
}
