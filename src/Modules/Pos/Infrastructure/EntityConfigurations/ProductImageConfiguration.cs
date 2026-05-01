using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Products;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.ImageUrl).IsRequired();
        builder.Property(x => x.Order).IsRequired(false);
        builder.HasOne(x => x.Product).WithMany(x => x.Images).HasForeignKey(x => x.ProductId);
        builder.Property(x => x.Alt).HasMaxLength(100).IsRequired(false);
    }
}
