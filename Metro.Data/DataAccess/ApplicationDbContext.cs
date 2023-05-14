using Metro.Data.Entities;
using Metro.Data.Infrastructure;
using Metro.Data.Infrastructure.Configuration.ConfigurationEntity;
using Microsoft.EntityFrameworkCore;

namespace Metro.Data.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Branch> Branches { get; set; } = null!;

        public DbSet<Station> Stations { get; set; } = null!;

        public DbSet<Route> Routes { get; set; } = null!;

        public ApplicationDbContext()
        {
            Database.EnsureCreated();
            DataInitializer.InitializerAsync(this).GetAwaiter().GetResult();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=MetroDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BranchConfiguration());
            modelBuilder.ApplyConfiguration(new StationConfiguration());
            modelBuilder.ApplyConfiguration(new RouteConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
