using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Addresses;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.Street).IsRequired();
        builder.Property(x => x.InnerAddress).IsRequired(false);
        builder.Property(x => x.ZipCode).IsRequired(false);
        builder.Property(x => x.Street).IsRequired();
        builder.HasMany(x => x.Customers).WithOne(x => x.Address).HasForeignKey(x => x.AddressId);
        builder.HasMany(x => x.Stands).WithOne(x => x.Address).HasForeignKey(x => x.AddressId);
        builder.HasMany(x => x.Suppliers).WithOne(x => x.Address).HasForeignKey(x => x.AddressId);
        builder.HasMany(x => x.Warehouses).WithOne(x => x.Address).HasForeignKey(x => x.AddressId);
    }
}
