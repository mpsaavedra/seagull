using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Octupus.Api.Features.Payments;
using Octupus.Api.Features.Purchases;
using Seagull.Extensions;

namespace Octupus.Api.Data.Configurations;

public class StandSalePaymentConfiguration : IEntityTypeConfiguration<StandSalePayment>
{
    public void Configure(EntityTypeBuilder<StandSalePayment> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.HasOne(x => x.StandSale).WithMany(x => x.SalePayments).HasForeignKey(x => x.StandSaleId);
        builder.Property(x => x.Tax).IsRequired(false);
        builder.Property(x => x.Discount).IsRequired(false);
        builder.Property(x => x.TotalPrice).IsRequired();
        builder.Property(x => x.SubTotal).IsRequired();
        builder.HasOne(x => x.Price).WithMany(x => x.StandSalePayments).HasForeignKey(x => x.PriceId);
        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.DueDate).IsRequired(false);
        builder.Property(x => x.PaymentType).IsRequired();
    }
}
