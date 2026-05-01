using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seagull.Data;

namespace Seagull.Extensions;

/// <summary>
/// EntityTypeBuilder related extensions
/// </summary>
public static class EntityTypeBuilderExtensions
{
    public static EntityTypeBuilder<T> ConfigureAuditableEntity<T>(this EntityTypeBuilder<T> builder,
        int maxLengthUser = 256,
        bool generatedKeyValue = true)
        where T: AuditableEntity
    {
        if (generatedKeyValue)
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        else
            builder.Property(x => x.Id).ValueGeneratedNever();
            
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy).HasMaxLength(maxLengthUser).IsRequired(false);
        builder.Property(x => x.ModifiedAt).IsRequired(false);
        builder.Property(x => x.ModifiedBy).HasMaxLength(maxLengthUser).IsRequired(false);
        builder.Property(x => x.DeletedAt).IsRequired(false);
        builder.Property(x => x.DeletedBy).HasMaxLength(maxLengthUser).IsRequired(false);
        builder.HasIndex(x => x.Id, $"IX_{nameof(T)}_Id").IsUnique();
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.RowVersion).IsUnique();
        builder.Property(x => x.RowVersion).IsConcurrencyToken();

        return builder;
    }
}
