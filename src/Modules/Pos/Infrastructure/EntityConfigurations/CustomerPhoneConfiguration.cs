using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Common;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class CustomerPhoneConfiguration : IEntityTypeConfiguration<CustomerPhone>
{
    public void Configure(EntityTypeBuilder<CustomerPhone> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.Number).HasMaxLength(11).IsRequired();
        builder.Property(x => x.PhoneType).IsRequired();
        builder.HasOne(x => x.Customer).WithMany(x => x.ContactPhones).HasForeignKey(x => x.CustomerId);
        builder.HasIndex(x => x.Number);
    }
}
