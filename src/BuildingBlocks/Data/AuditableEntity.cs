using System;
using Swashbuckle.AspNetCore.Annotations;

namespace Seagull.Data;

public interface IAuditableEntity
{
    DateTime CreatedAt { get; }
    string? CreatedBy { get; }
    DateTime? DeletedAt { get; }
    string? DeletedBy { get; }
    DateTime? ModifiedAt { get; }
    string? ModifiedBy { get;  }
    Ulid RowVersion { get; }
}

public abstract class AuditableEntity : Entity, IAuditableEntity
{
    [SwaggerIgnore]
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    [SwaggerIgnore]
    public string? CreatedBy { get; protected set; }
    [SwaggerIgnore]
    public DateTime? DeletedAt { get; protected set; }
    [SwaggerIgnore]
    public string? DeletedBy { get; protected set; }
    [SwaggerIgnore]
    public DateTime? ModifiedAt { get; protected set; }
    [SwaggerIgnore]
    public string? ModifiedBy { get;  protected set; }
    [SwaggerIgnore]
    public Ulid RowVersion { get; protected set; } = Ulid.NewUlid();
}
