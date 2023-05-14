using FranksBar.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FranksBar.DataAccess.Mappings;

public class BreweryBeerMapping : IEntityTypeConfiguration<BreweryBeer>
{
    public void Configure(EntityTypeBuilder<BreweryBeer> builder)
    {
        builder.ToTable("BreweryBeers");
        builder.HasKey(_ => _.Id);

        builder.HasOne(_ => _.Brewery)
            .WithMany(_ => _.Beers)
            .HasForeignKey(_ => _.BreweryId);

        //builder.HasOne(_ => _.Beer)
        //    .WithMany(_ => _.bee)
        //    .HasForeignKey(_ => _.BeerId);
    }
}