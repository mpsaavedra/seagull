using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Phones;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class WarehousePhoneConfiguration : IEntityTypeConfiguration<WarehousePhone>
{
    public void Configure(EntityTypeBuilder<WarehousePhone> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.HasOne(x => x.Warehouse).WithMany(x => x.ContactPhones).HasForeignKey(x => x.WarehouseId);
        builder.Property(x => x.Number).HasMaxLength(100).IsRequired();
        builder.Property(x => x.PhoneType).IsRequired();
        builder.HasIndex(x => x.Number);
    }
}
