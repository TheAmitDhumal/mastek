using mastek.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Threading;

namespace mastek.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Bar> Bars { get; set; }
        public DbSet<BreweryBeerLink> BreweryBeerLinks { get; set; }
        public DbSet<BarBeerLink> BarBeerLinks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BreweryBeerLink>()
                .HasNoKey();

            modelBuilder.Entity<BarBeerLink>()
                .HasNoKey();

        }
    }
}
