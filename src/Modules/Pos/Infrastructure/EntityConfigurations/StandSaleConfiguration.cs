using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Sales;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class StandSaleConfiguration : IEntityTypeConfiguration<StandSale>
{
    public void Configure(EntityTypeBuilder<StandSale> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.HasOne(x => x.Stand).WithMany(x => x.Sales).HasForeignKey(x => x.StandId);
        builder.Property(x => x.Number).IsRequired();
        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.DueDate).IsRequired(false);
        builder.Property(x => x.Tax).IsRequired(false);
        builder.Property(x => x.Discount).IsRequired(false);
        builder.Property(x => x.TotalPrice).IsRequired(false);
        builder.Property(x => x.SubTotal).IsRequired(false);
        builder.HasMany(x => x.SaleProducts).WithOne(x => x.StandSale).HasForeignKey(x => x.StandSaleId);
        builder.HasMany(x => x.SalePayments).WithOne(x => x.StandSale).HasForeignKey(x => x.StandSaleId);
        builder.Property(x => x.ShippingCost).IsRequired(false);
        builder.HasOne(x => x.Shipping).WithMany(x => x.StandSales).HasForeignKey(x => x.ShippingId);
        builder.HasIndex(x => x.Number);
    }
}
