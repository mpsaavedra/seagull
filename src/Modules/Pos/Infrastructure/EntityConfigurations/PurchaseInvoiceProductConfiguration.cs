using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Products;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class PurchaseInvoiceProductConfiguration : IEntityTypeConfiguration<PurchaseInvoiceProduct>
{
    public void Configure(EntityTypeBuilder<PurchaseInvoiceProduct> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.HasOne(x => x.PurchaseInvoice).WithMany(x => x.Products).HasForeignKey(x => x.PurchaseInvoiceId);
        builder.HasOne(x => x.Product).WithMany(x => x.PurchaseInvoiceProducts).HasForeignKey(x => x.ProductId);
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.SalePrice);
        builder.HasOne(x => x.SaleCost).WithMany(x => x.PurchaseInvoiceProducts).HasForeignKey(x => x.SaleCostId);
        builder.Property(x => x.Details).IsRequired(false);
        builder.HasOne(x => x.MeasureUnit).WithMany(x => x.PurchaseInvoiceProducts).HasForeignKey(x => x.MeasureUnitId);
    }
}
