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
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Prize> Prizes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Prize>()
                .HasRequired(e => e.WinningPlayer)
                .WithMany(e => e.PrizesWon)
                .HasForeignKey(e => e.WinningPlayerID);

            modelBuilder.Entity<Prize>()
                .HasRequired(e => e.LosingPlayer)
                .WithMany(e => e.PrizesLost)
                .HasForeignKey(e => e.LosingPlayerID);

            modelBuilder.Entity<Bet>()
                .HasOptional(e => e.Throw)
                .WithMany(e => e.Bets)
                .HasForeignKey(e => e.ThrowID);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
