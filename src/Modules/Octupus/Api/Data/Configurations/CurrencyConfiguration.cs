using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Octupus.Api.Features.Moneys;
using Seagull.Extensions;

namespace Octupus.Api.Data.Configurations;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.Name).HasMaxLength(120).IsRequired();
        builder.HasMany(x => x.Moneys).WithOne(x => x.Currency).HasForeignKey(x => x.CurrencyId);
    }
}
