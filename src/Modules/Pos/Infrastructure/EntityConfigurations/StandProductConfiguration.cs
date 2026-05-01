using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Products;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class StandProductConfiguration : IEntityTypeConfiguration<StandProduct>
{
    public void Configure(EntityTypeBuilder<StandProduct> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.HasOne(x => x.Stand).WithMany(x => x.Products).HasForeignKey(x => x.StandId);
        builder.HasOne(x => x.Product).WithMany(x => x.StandProducts).HasForeignKey(x => x.ProductId);
        builder.Property(x => x.Quantity).IsRequired(); //.HasPrecision(8, 2);
        builder.Property(x => x.Price).IsRequired();
        builder.HasOne(x => x.Cost).WithMany(x => x.StandProducts).HasForeignKey(x => x.CostId);
        builder.Property(x => x.ReOrderLevel).IsRequired(false);
        builder.HasMany(x => x.StandSaleProducts).WithOne(x => x.StandProduct).HasForeignKey(x => x.StandProducId);
        builder.HasOne(x => x.Warehouse).WithMany(x => x.StandProducts).HasForeignKey(x => x.WarehouseId);
        builder.Ignore(x => x.OnStock);
    }
}
