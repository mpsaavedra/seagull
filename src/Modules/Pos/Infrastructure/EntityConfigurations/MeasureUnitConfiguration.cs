using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.MeasureUnits;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class MeasureUnitConfiguration : IEntityTypeConfiguration<MeasureUnit>
{
    public void Configure(EntityTypeBuilder<MeasureUnit> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
        builder.Property(x => x.Symbol).HasMaxLength(5).IsRequired(false);
        builder.HasMany(x => x.Products).WithOne(x => x.MeasureUnit).HasForeignKey(x => x.MeasureUnitId);
        builder.HasMany(x => x.InvoiceProducts).WithOne(x => x.MeasureUnit).HasForeignKey(x => x.MeasureUnitId);
        builder.HasMany(x => x.PurchaseInvoiceProducts).WithOne(x => x.MeasureUnit).HasForeignKey(x => x.MeasureUnitId);
        builder.HasIndex(x => x.Symbol).IsUnique().IsDescending();
    }
}
