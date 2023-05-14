using FranksBar.DataAccess.Entities;
using FranksBar.DataAccess.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FranksBar.DataAccess
{
    public class DBarContext : DbContext
    {
        public DBarContext(DbContextOptions<DBarContext> options) : base(options)
        {

        }

        public virtual DbSet<Bar> Bars { get; set; }

        public virtual DbSet<BarBeer> BarBeers { get; set; }

        public virtual DbSet<Beer?> Beers { get; set; }

        public virtual DbSet<Brewery> Breweries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BarMapping());
            modelBuilder.ApplyConfiguration(new BeerMapping());
            modelBuilder.ApplyConfiguration(new BreweryMapping());
            modelBuilder.ApplyConfiguration(new BreweryBeerMapping());
            modelBuilder.ApplyConfiguration(new BarBeerMapping());
        }
    }
}