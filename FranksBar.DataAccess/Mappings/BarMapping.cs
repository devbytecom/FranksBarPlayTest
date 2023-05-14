using Microsoft.EntityFrameworkCore;
using FranksBar.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FranksBar.DataAccess.Mappings
{
    public class BarMapping : IEntityTypeConfiguration<Bar>
    {
        public void Configure(EntityTypeBuilder<Bar> builder)
        {
            builder.ToTable("Bars");
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Name).IsRequired();
            builder.Property(_ => _.Address).IsRequired();

            builder.HasMany(_ => _.BarBeers)
                .WithOne(_ => _.Bar)
                .HasForeignKey(_ => _.Id);
        }
    }
}
