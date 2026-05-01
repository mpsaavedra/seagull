using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seagull.Extensions;

namespace Tests.Shared.Data.Configurations;

public class FakeUserConfiguration : IEntityTypeConfiguration<FakeUser>
{
    public void Configure(EntityTypeBuilder<FakeUser> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
        builder.Property(x => x.Username).HasMaxLength(20).IsRequired();
    }
}
