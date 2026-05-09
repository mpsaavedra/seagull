using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Octupus.Api.Features.Moneys;
using Seagull.Extensions;

namespace Octupus.Api.Data.Configurations;

public class MoneyConfiguration : IEntityTypeConfiguration<Money>
{
    public void Configure(EntityTypeBuilder<Money> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.Amount).IsRequired();
        builder.HasOne(x => x.Currency).WithMany(x => x.Moneys).HasForeignKey(x => x.CurrencyId);
        builder.HasMany(x => x.InvoiceProducts).WithOne(x => x.Cost).HasForeignKey(x => x.CostId);
        builder.HasMany(x => x.PurchaseInvoiceProducts).WithOne(x => x.SaleCost).HasForeignKey(x => x.SaleCostId);
        builder.HasMany(x => x.Products).WithOne(x => x.Cost).HasForeignKey(x => x.CostId);
        builder.HasMany(x => x.StandSalePayments).WithOne(x => x.Price).HasForeignKey(x => x.PriceId);
        builder.HasMany(x => x.PurchaseProducts).WithOne(x => x.PurchasePrice).HasForeignKey(x => x.PurchasePriceId);
        builder.HasMany(x => x.SalePayments).WithOne(x => x.Price).HasForeignKey(x => x.PriceId);
        builder.HasMany(x => x.StandSaleProducts).WithOne(x => x.Cost).HasForeignKey(x => x.CostId);
        builder.HasMany(x => x.SaleProducts).WithOne(x => x.SaleCost).HasForeignKey(x => x.SaleCostId);
    }
}
