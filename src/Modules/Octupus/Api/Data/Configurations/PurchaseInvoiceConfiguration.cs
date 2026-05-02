using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Octupus.Api.Features.Invoices;
using Seagull.Extensions;

namespace Octupus.Api.Data.Configurations;

public class PurchaseInvoiceConfiguration : IEntityTypeConfiguration<PurchaseInvoice>
{
    public void Configure(EntityTypeBuilder<PurchaseInvoice> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.HasOne(x => x.Purchase).WithOne(x => x.PurchaseInvoice).HasForeignKey<PurchaseInvoice>(x => x.PurchaseId);
        builder.Property(x => x.Number).HasMaxLength(120).IsRequired();
        builder.Property(x => x.Date).IsRequired();
        builder.HasMany(x => x.Products).WithOne(x => x.PurchaseInvoice).HasForeignKey(x => x.PurchaseInvoiceId);
        builder.HasIndex(x => x.Number);
    }
}
