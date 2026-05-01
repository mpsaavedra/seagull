using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Products;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class PurchaseProductConfiguration : IEntityTypeConfiguration<PurchaseProduct>
{
    public void Configure(EntityTypeBuilder<PurchaseProduct> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.HasOne(x => x.Product).WithMany(x => x.PurchaseProducts).HasForeignKey(x => x.ProductId);
        builder.Property(x => x.Date).IsRequired(false);
        builder.Property(x => x.DueDate).IsRequired(false);
        builder.HasOne(x => x.Purchase).WithMany(x => x.PurchaseProducts).HasForeignKey(x => x.PurchaseId);
        builder.Property(x => x.Quantity).IsRequired();
        builder.HasOne(x => x.PurchasePrice).WithMany(x => x.PurchaseProducts).HasForeignKey(x => x.PurchasePriceId);
        builder.Property(x => x.Details).IsRequired(false);
        builder.HasOne(x => x.Supplier).WithMany(x => x.PurchaseProducts).HasForeignKey(x => x.SupplierId);
        builder.Ignore(x => x.Cost);
    }
}
