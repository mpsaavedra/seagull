using System;

namespace Seagull.Data;

public interface IEntity
{
    string Id { get; }
    bool IsEnable { get; }
    bool IsDeleted { get;  }
    IReadOnlyCollection<object> DomainEvents { get; }
    void ClearDomainEvents();
    void Disable();
    void Enable();
    void MarkAsDeleted();
}

public abstract class Entity : IEntity
{
    private List<object> _domainEvents = new();
    
    public string Id { get; protected set; } = Ulid.NewUlid().ToString();

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        return Id.Equals(other.Id);
    }

    public override int GetHashCode() => HashCode.Combine(GetType(), Id);
    public bool IsEnable { get; protected set; }
    public bool IsDeleted { get; protected set; }

    public void Disable() => IsEnable = false;
    public void Enable() => IsEnable = true;
    public void MarkAsDeleted() => IsDeleted = false;

    /// <summary>
    /// returns the list of registered events
    /// </summary>
    public IReadOnlyCollection<object> DomainEvents => _domainEvents.AsReadOnly();
    
    /// <summary>
    /// adds a new domain event
    /// </summary>
    /// <param name="event"></param>
    protected void AddEvent(object @event) => _domainEvents.Add(@event);
    
    /// <summary>
    /// Clear all registered event
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();
}
