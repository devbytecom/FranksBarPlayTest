using FranksBar.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FranksBar.DataAccess.Mappings;

public class BreweryMapping : IEntityTypeConfiguration<Brewery>
{
    public void Configure(EntityTypeBuilder<Brewery> builder)
    {
        builder.ToTable("Breweries");
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Name).IsRequired();
            
        builder.HasMany(_ => _.Beers)
            .WithOne(_ => _.Brewery);
    }
}