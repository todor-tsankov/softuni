using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics {get; set;}
        public DbSet<Game> Games {get; set;}
        public DbSet<Team> Teams {get; set;}
        public DbSet<Color> Colors {get; set;}
        public DbSet<Player> Players {get; set;}
        public DbSet<Position> Positions {get; set;}
        public DbSet<Town> Towns {get; set;}
        public DbSet<Country> Countries {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FootballBetting;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>()
                        .HasKey(x => new { x.PlayerId, x.GameId });

            modelBuilder.Entity<Game>()
                        .HasOne(x => x.HomeTeam)
                        .WithMany(x => x.HomeGames)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Game>()
                        .HasOne(x => x.AwayTeam)
                        .WithMany(x => x.AwayGames)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Team>()
                        .HasOne(x => x.PrimaryKitColor)
                        .WithMany(x => x.PrimaryKitTeams)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Team>()
                        .HasOne(x => x.SecondaryKitColor)
                        .WithMany(x => x.SecondaryKitTeams)
                        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
