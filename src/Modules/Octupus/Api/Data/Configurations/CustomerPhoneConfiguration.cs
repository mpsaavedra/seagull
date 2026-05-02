using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Octupus.Api.Features.Phones;
using Seagull.Extensions;

namespace Octupus.Api.Data.Configurations;

public class CustomerPhoneConfiguration : IEntityTypeConfiguration<CustomerPhone>
{
    public void Configure(EntityTypeBuilder<CustomerPhone> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.Number).HasMaxLength(11).IsRequired();
        builder.Property(x => x.PhoneType).IsRequired();
        builder.HasOne(x => x.Customer).WithMany(x => x.ContactPhones).HasForeignKey(x => x.CustomerId);
        builder.HasIndex(x => x.Number);
    }
}
