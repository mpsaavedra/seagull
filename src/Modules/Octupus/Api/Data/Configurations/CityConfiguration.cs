using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Octupus.Api.Features.Cities;
using Seagull.Extensions;

namespace Octupus.Api.Data.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ConfigureAuditableEntity();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.ZipCode).IsRequired();
        builder.Property(x => x.Town).IsRequired();
        builder.Property(x => x.State).IsRequired();
        builder.HasMany(x => x.Addresses).WithOne(x => x.City).HasForeignKey(x => x.CityId);
    }
}
