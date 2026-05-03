using System;
using Swashbuckle.AspNetCore.Annotations;

namespace Seagull.Data;

public interface IAuditableEntity
{
    DateTime CreatedAt { get; set; }
    string? CreatedBy { get; set; }
    DateTime? DeletedAt { get; set; }
    string? DeletedBy { get; set; }
    DateTime? ModifiedAt { get; set; }
    string? ModifiedBy { get;  set; }
    string RowVersion { get; }
}

public abstract class AuditableEntity : Entity, IAuditableEntity
{
    [SwaggerIgnore]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [SwaggerIgnore]
    public string? CreatedBy { get; set; }
    [SwaggerIgnore]
    public DateTime? DeletedAt { get; set; }
    [SwaggerIgnore]
    public string? DeletedBy { get; set; }
    [SwaggerIgnore]
    public DateTime? ModifiedAt { get; set; }
    [SwaggerIgnore]
    public string? ModifiedBy { get;  set; }
    [SwaggerIgnore]
    public string RowVersion { get; protected set; } = Ulid.NewUlid().ToString();
}
