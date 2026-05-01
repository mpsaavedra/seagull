using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Domain.Moneys;
using Seagull.Extensions;

namespace Pos.Infrastructure.EntityConfigurations;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.Name).HasMaxLength(120).IsRequired();
        builder.HasMany(x => x.Moneys).WithOne(x => x.Currency).HasForeignKey(x => x.CurrentyId);
    }
}
