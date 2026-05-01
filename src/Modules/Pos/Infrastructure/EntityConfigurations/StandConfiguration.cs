using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Stands;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class StandConfiguration : IEntityTypeConfiguration<Stand>
{
    public void Configure(EntityTypeBuilder<Stand> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.Name).HasMaxLength(120).IsRequired();
        builder.Property(x => x.Description).IsRequired(false);
        builder.Property(x => x.Capacity).IsRequired(false);
        builder.Property(x => x.IsAvailable).IsRequired();
        builder.Property(x => x.StandType).IsRequired();
        builder.OwnsOne(x => x.Address);
        builder.HasMany(x => x.ContactPhones).WithOne(x => x.Stand).HasForeignKey(x => x.StandId);
        builder.HasMany(x => x.Products).WithOne(x => x.Stand).HasForeignKey(x => x.StandId);
        builder.HasMany(x => x.Sales).WithOne(x => x.Stand).HasForeignKey(x => x.StandId);
    }
}
