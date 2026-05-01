using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seagull.Extensions;

namespace Tests.Shared.Data.Configurations;

public class FakeCategoryConfiguration : IEntityTypeConfiguration<FakeCategory>
{
    public void Configure(EntityTypeBuilder<FakeCategory> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(x => x.Books).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
    }
}
