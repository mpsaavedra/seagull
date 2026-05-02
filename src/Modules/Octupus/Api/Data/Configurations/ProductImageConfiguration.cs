using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Octupus.Api.Features.Products;
using Seagull.Extensions;

namespace Octupus.Api.Data.Configurations;

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
