using Microsoft.EntityFrameworkCore;
using MyServer.Models;

namespace MyServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Ascent> Ascents { get; set; }
        public DbSet<Boulder> Boulders { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ascent>()
              .HasOne(x => x.ProposedGrade)
              .WithMany(x => x.Ascents)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ascent>()
              .HasOne(x => x.User)
              .WithMany(x => x.Ascents)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Boulder>()
              .HasOne(x => x.Author)
              .WithMany(x => x.CreatedBoulders)
              .OnDelete(DeleteBehavior.NoAction);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Database=Toshko8a;Server=.;Integrated Security=true;");
        }
    }
}
