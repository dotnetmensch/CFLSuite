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
                .HasRequired(e => e.WinningParticipant)
                .WithMany(e => e.PrizesWon)
                .HasForeignKey(e => e.WinningParticipantID);

            modelBuilder.Entity<Prize>()
                .HasRequired(e => e.LosingParticipant)
                .WithMany(e => e.PrizesLost)
                .HasForeignKey(e => e.LosingParticipantID);

            modelBuilder.Entity<Bet>()
                .HasOptional(e => e.Throw)
                .WithMany(e => e.Bets)
                .HasForeignKey(e => e.ThrowID);

            modelBuilder.Entity<Bet>()
                .HasOptional(e => e.ParentBet)
                .WithMany(e => e.ChildBets)
                .HasForeignKey(e => e.ParentBetID);

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
