using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Octupus.Api.Features.Invoices;
using Seagull.Extensions;

namespace Octupus.Api.Data.Configurations;

public class InvoiceProductConfiguration : IEntityTypeConfiguration<InvoiceProduct>
{
    public void Configure(EntityTypeBuilder<InvoiceProduct> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.HasOne(x => x.Product).WithMany(x => x.InvoiceProducts).HasForeignKey(x => x.ProductId);
        builder.HasOne(x => x.Cost).WithMany(x => x.InvoiceProducts).HasForeignKey(x => x.CostId);
        // builder.HasOne(x => x.MeasureUnit).WithMany(x => x.PurchaseInvoiceProducts)
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.Description).IsRequired(false);
    }
}
