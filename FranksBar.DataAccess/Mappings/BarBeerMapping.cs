using FranksBar.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FranksBar.DataAccess.Mappings;

public class BarBeerMapping : IEntityTypeConfiguration<BarBeer>
{
    public void Configure(EntityTypeBuilder<BarBeer> builder)
    {
        builder.ToTable("BarBeers");
        builder.HasKey(_ => _.Id);

        builder.HasOne(_ => _.Bar)
            .WithMany(_ => _.BarBeers)
            .HasForeignKey(_ => _.BarId);

        builder.HasOne(_ => _.Beer)
            .WithMany(_ => _.BarBeers)
            .HasForeignKey(_ => _.BeerId);
    }
}