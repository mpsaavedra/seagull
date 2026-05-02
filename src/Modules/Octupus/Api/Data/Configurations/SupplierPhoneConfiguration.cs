using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Octupus.Api.Features.Phones;
using Seagull.Extensions;

namespace Octupus.Api.Data.Configurations;

public class SupplierPhoneConfiguration : IEntityTypeConfiguration<SupplierPhone>
{
    public void Configure(EntityTypeBuilder<SupplierPhone> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.HasOne(x => x.Supplier).WithMany(x => x.ContactPhones).HasForeignKey(x => x.SupplierId);
        builder.Property(x => x.Number).HasMaxLength(100).IsRequired();
        builder.Property(x => x.PhoneType).IsRequired();
        builder.HasIndex(x => x.Number);
    }
}
