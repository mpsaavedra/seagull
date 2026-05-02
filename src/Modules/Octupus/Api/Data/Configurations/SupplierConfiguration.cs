using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Octupus.Api.Features.Suppliers;
using Seagull.Extensions;

namespace Octupus.Api.Data.Configurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.Name).HasMaxLength(120).IsRequired();
        builder.OwnsOne(x => x.Address);
        builder.HasMany(x => x.ContactPhones).WithOne(x => x.Supplier).HasForeignKey(x => x.SupplierId);
        builder.HasMany(x => x.PurchaseProducts).WithOne(x => x.Supplier).HasForeignKey(x => x.SupplierId);
        // builder.HasMany(x => x.Invoices).WithOne(x => x.)
    }
}
