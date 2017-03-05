using CFLSuite.DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.Data
{
    public class CFLSuiteDB : DbContext
    {
        public CFLSuiteDB()
            :base("name=CFLSuiteDb")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<BetParticipant> BetParticipants { get; set; }
        public DbSet<Redemption> Redemptions { get; set; }
        public DbSet<RedemptionParticipant> RedemptionParticipants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Player>()
                .HasMany(c => c.Redemptions)
                .WithRequired(c => c.Player)
                .HasForeignKey(c => c.PlayerID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
