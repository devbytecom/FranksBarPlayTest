using FranksBar.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FranksBar.DataAccess.Mappings;

public class BeerMapping : IEntityTypeConfiguration<Beer>
{
    public void Configure(EntityTypeBuilder<Beer> builder)
    {
        builder.ToTable("Beers");
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Name).IsRequired();

        //builder.HasMany(_ => _.Bars)
        //    .WithMany(_ => _.Beers);

        //builder.HasOne(_ => _.Brewery)
        //    .WithMany(_ => _.Beers);
    }
}