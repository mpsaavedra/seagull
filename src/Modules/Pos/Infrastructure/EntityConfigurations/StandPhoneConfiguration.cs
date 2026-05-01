using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Phones;
using Pos.Domain.Stands;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class StandPhoneConfiguration : IEntityTypeConfiguration<StandPhone>
{
    public void Configure(EntityTypeBuilder<StandPhone> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.HasOne(x => x.Stand).WithMany(x => x.ContactPhones).HasForeignKey(x => x.StandId);
        builder.Property(x => x.Number).HasMaxLength(100).IsRequired();
        builder.Property(x => x.PhoneType).IsRequired();
        builder.HasIndex(x => x.Number);
    }
}
