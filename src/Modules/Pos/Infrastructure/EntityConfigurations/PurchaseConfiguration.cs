using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Purchases;

namespace Pos.Infrastructure.EntityConfigurations;

public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.Property(x => x.Number).HasMaxLength(120).IsRequired();
        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.DueDate).IsRequired(false);
        builder.Property(x => x.Tax).IsRequired(false);
        builder.Property(x => x.Discount).IsRequired(false);
        builder.Property(x => x.TotalPrice).IsRequired(false);
        builder.Property(x => x.SubTotal).IsRequired(false);
        builder.HasMany(x => x.PurchaseProducts).WithOne(x => x.Purchase).HasForeignKey(x => x.PurchaseId);
        builder.HasMany(x => x.PurchasePayments).WithOne(x => x.Purchase).HasForeignKey(x => x.PurchaseId);
        builder.HasOne(x => x.Warehouse).WithMany(x => x.Purchases).HasForeignKey(x => x.WarehouseId);
        builder.Property(x => x.ShippingCost).IsRequired(false);
        builder.HasOne(x => x.Shipping).WithMany(x => x.Purchases).HasForeignKey(x => x.ShippingId);
        builder.HasOne(x => x.PurchaseInvoice).WithOne(x => x.Purchase);
    }
}
