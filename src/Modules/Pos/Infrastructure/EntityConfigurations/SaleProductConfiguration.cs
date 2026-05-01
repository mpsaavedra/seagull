using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Products;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class SaleProductConfiguration : IEntityTypeConfiguration<SaleProduct>
{
    public void Configure(EntityTypeBuilder<SaleProduct> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.HasOne(x => x.Product).WithMany(x => x.SaleProducts).HasForeignKey(x => x.ProductId);
        builder.HasOne(x => x.Sale).WithMany(x => x.SaleProducts).HasForeignKey(x => x.SaleId);
        builder.HasOne(x => x.Warehouse).WithMany(x => x.SaleProducts).HasForeignKey(x => x.WarehouseId);
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.SalePrice).IsRequired();
        builder.HasOne(x => x.SaleCost).WithMany(x => x.SaleProducts).HasForeignKey(x => x.SaleCostId);
        builder.Property(x => x.Details).IsRequired(false);
    }
}
