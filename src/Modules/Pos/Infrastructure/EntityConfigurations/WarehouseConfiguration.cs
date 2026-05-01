using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Warehouses;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.Name).HasMaxLength(120).IsRequired();
        builder.OwnsOne(x => x.Address);
        builder.HasMany(x => x.ContactPhones).WithOne(x => x.Warehouse).HasForeignKey(x => x.WarehouseId);
        builder.Property(x => x.IsAvailable).IsRequired();
        builder.HasMany(x => x.Purchases).WithOne(x => x.Warehouse).HasForeignKey(x => x.WarehouseId);
        builder.HasMany(x => x.Products).WithOne(x => x.Warehouse).HasForeignKey(x => x.WarehouseId);
        builder.HasMany(x => x.StandProducts).WithOne(x => x.Warehouse).HasForeignKey(x => x.WarehouseId);
        builder.HasMany(x => x.Sales).WithOne(x => x.Warehouse).HasForeignKey(x => x.WarehouseId);
        builder.HasMany(x => x.SaleProducts).WithOne(x => x.Warehouse).HasForeignKey(x => x.WarehouseId);
    }
}
