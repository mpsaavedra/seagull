using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Products;
using Pos.Domain.Sales;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

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
