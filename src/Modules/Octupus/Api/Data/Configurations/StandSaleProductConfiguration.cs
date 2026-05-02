using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Octupus.Api.Features.Products;
using Seagull.Extensions;

namespace Octupus.Api.Data.Configurations;

public class StandSaleProductConfiguration : IEntityTypeConfiguration<StandSaleProduct>
{
    public void Configure(EntityTypeBuilder<StandSaleProduct> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.HasOne(x => x.StandSale).WithMany(x => x.SaleProducts).HasForeignKey(x => x.StandSaleId);
        builder.HasOne(x => x.StandProduct).WithMany(x => x.StandSaleProducts).HasForeignKey(x => x.StandProducId);
        builder.HasOne(x => x.Cost).WithMany(x => x.StandSaleProducts).HasForeignKey(x => x.CostId);
        builder.Property(x => x.Price).IsRequired();
        builder.Ignore(x => x.Earn);
    }
}
