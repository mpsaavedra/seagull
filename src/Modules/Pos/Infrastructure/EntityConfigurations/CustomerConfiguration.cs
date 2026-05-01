using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Customers;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
        builder.Property(x => x.ContactName).HasMaxLength(300).IsRequired(false);
        builder.Property(x => x.Email).HasMaxLength(200).IsRequired(false);
        builder.HasMany(x => x.ContactPhones).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);
        builder.OwnsOne(x => x.Address);
        builder.Property(x => x.Website).HasMaxLength(300).IsRequired(false);
        builder.Property(x => x.Notes).IsRequired(false);
        builder.Property(x => x.CommercialNumber).HasMaxLength(50).IsRequired(false);
        builder.Property(x => x.PreviousBalance).IsRequired(false);
        builder.HasMany(x => x.Sales).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);
        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(x => x.CommercialNumber).IsUnique();
    }
}
