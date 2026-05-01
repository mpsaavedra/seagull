using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Payments;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class SalePaymentConfiguration : IEntityTypeConfiguration<SalePayment>
{
    public void Configure(EntityTypeBuilder<SalePayment> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.HasOne(x => x.Sale).WithMany(x => x.SalePayments).HasForeignKey(x => x.SaleId);
        builder.Property(x => x.Tax).IsRequired(false);
        builder.Property(x => x.Discount).IsRequired(false);
        builder.Property(x => x.TotalPrice).IsRequired(false);
        builder.Property(x => x.SubTotal).IsRequired(false);
        builder.HasOne(x => x.Price).WithMany(x => x.SalePayments).HasForeignKey(x => x.PriceId);
        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.DueDate).IsRequired(false);
        builder.Property(x => x.PaymentType).IsRequired(false);
    }
}
