using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Data.SqlTypes;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=SalesDatabase;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                        .Property(x => x.Date)
                        .HasColumnType("date");

            modelBuilder.Entity<Customer>()
                        .Property(x => x.Email)
                        .IsUnicode(false);

            modelBuilder.Entity<Product>()
                        .Property(x => x.Description)
                        .HasDefaultValue("No description");

            modelBuilder.Entity<Sale>()
                        .Property(x => x.Date)
                        .HasDefaultValueSql("GETDATE()");
        }
    }
}
