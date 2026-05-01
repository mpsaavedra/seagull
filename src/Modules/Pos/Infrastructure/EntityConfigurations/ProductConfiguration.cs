using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Products;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
        builder.Property(x => x.Description).IsRequired(false);
        builder.Property(x => x.SKU).HasMaxLength(128).IsRequired();
        builder.HasMany(x => x.Images).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
        builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        // builder.HasMany(x => x.InvoiceProducts).WithOne(x => x.Invoice)
        builder.Property(x => x.ExpirationDate).IsRequired(false);
        builder.HasOne(x => x.Cost).WithMany(x => x.Products).HasForeignKey(x => x.CostId);
        builder.HasMany(x => x.PurchaseProducts).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
        builder.HasMany(x => x.WarehouseProducts).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
        builder.HasMany(x => x.StandProducts).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
        builder.HasMany(x => x.SaleProducts).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
        builder.HasOne(x => x.MeasureUnit).WithMany(x => x.Products).HasForeignKey(x => x.MeasureUnitId);
    }
}
