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

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<ThrowType> ThrowTypes { get; set; }
        public DbSet<Throw> Throws { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Player>()
                .HasMany(e => e.Throws)
                .WithRequired(e => e.ThrowingPlayer)
                .HasForeignKey(e => e.ThrowingPlayerID);

            modelBuilder.Entity<Player>()
                .HasMany(e => e.PayoutToPlayers)
                .WithOptional(e => e.ReceivingPlayer)
                .HasForeignKey(e => e.ReceivingPlayerID);

            modelBuilder.Entity<Throw>()
                .HasMany(e => e.RedemptionThrows)
                .WithOptional(e => e.RedemptionForThrow)
                .HasForeignKey(e => e.RedemptionForThrowID);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
