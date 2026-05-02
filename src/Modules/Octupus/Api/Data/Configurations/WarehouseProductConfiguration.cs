using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Octupus.Api.Features.Products;
using Seagull.Extensions;

namespace Octupus.Api.Data.Configurations;

public class WarehouseProductConfiguration : IEntityTypeConfiguration<WarehouseProduct>
{
    public void Configure(EntityTypeBuilder<WarehouseProduct> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.HasOne(x => x.Product).WithMany(x => x.WarehouseProducts).HasForeignKey(x => x.ProductId);
        builder.HasOne(x => x.Warehouse).WithMany(x => x.Products).HasForeignKey(x => x.WarehouseId);
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.ReOrderLevel).IsRequired(false);
        builder.Ignore(x => x.OnStock);
    }
}
