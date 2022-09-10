using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class RouteLogDbContext :DbContext
    {
        public DbSet<Route> Routes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }
    }
}
