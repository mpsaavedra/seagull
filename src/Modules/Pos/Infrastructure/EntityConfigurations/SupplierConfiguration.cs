using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Suppliers;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

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
