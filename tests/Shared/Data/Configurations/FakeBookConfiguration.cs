using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seagull.Extensions;

namespace Tests.Shared.Data.Configurations;

public class FakeBookConfiguration : IEntityTypeConfiguration<FakeBook>
{
    public void Configure(EntityTypeBuilder<FakeBook> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
        builder.HasOne(x => x.Category).WithMany(x => x.Books).HasForeignKey(x => x.CategoryId);
    }
}
