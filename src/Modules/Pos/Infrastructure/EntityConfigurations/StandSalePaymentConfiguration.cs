using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Payments;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class StandSalePaymentConfiguration : IEntityTypeConfiguration<StandSalePayment>
{
    public void Configure(EntityTypeBuilder<StandSalePayment> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.HasOne(x => x.StandSale).WithMany(x => x.SalePayments).HasForeignKey(x => x.StandSaleId);
        builder.Property(x => x.Tax).IsRequired(false);
        builder.Property(x => x.Discount).IsRequired(false);
        builder.Property(x => x.TotalPrice).IsRequired(false);
        builder.Property(x => x.SubTotal).IsRequired(false);
        builder.HasOne(x => x.Price).WithMany(x => x.StandSalePayments).HasForeignKey(x => x.PriceId);
        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.DueDate).IsRequired(false);
        builder.Property(x => x.PaymentType).IsRequired();
    }
}
