using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Sales;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.HasOne(x => x.Warehouse).WithMany(x => x.Sales).HasForeignKey(x => x.WarehouseId);
        builder.HasOne(x => x.Customer).WithMany(x => x.Sales).HasForeignKey(x => x.CustomerId);
        builder.Property(x => x.Number).HasMaxLength(120).IsRequired();
        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.DueDate).IsRequired(false);
        builder.HasOne(x => x.Shipping).WithMany(x => x.Sales).HasForeignKey(x => x.ShippingId);
        builder.HasMany(x => x.SaleProducts).WithOne(x => x.Sale).HasForeignKey(x => x.SaleId);
        builder.HasMany(x => x.SalePayments).WithOne(x => x.Sale).HasForeignKey(x => x.SaleId);
        builder.HasIndex(x => x.Number);
    }
}
