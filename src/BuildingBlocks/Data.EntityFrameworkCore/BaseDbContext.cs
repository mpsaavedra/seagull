using Microsoft.EntityFrameworkCore;
using Seagull.Messaging;

namespace Seagull.Data.EntityFrameworkCore;

/// <summary>
/// Base DbContext that integrates with Seagull's IMessageBus for Domain Event publishing.
/// </summary>
public abstract class BaseDbContext(DbContextOptions options, IMessageBus messageBus) : DbContext(options)
{
    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        // Get all domain events from entities tracked by EF Core
        var domainEntities = ChangeTracker
            .Entries<IEntity>()
            .Select(e => e.Entity)
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(e => e.DomainEvents)
            .ToList();

        domainEntities.ForEach(e => e.ClearDomainEvents());

        foreach (var @event in domainEvents)
        {
            await messageBus.PublishAsync(@event, cancellationToken);
        }

        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        // For synchronous SaveChanges, we might need a synchronous publish if supported,
        // but Wolverine is mostly async.
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }
}
