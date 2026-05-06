namespace Seagull.Abstractions.Dtos;

/// <summary>
/// Base for all Dtos that includes the basic informatin thats part of the
/// ecosystem entity type
/// </summary>
public record DtoBase
{
    /// <summary>
    /// Dto id in case that the dto is used to create a new entity, this value must be null
    /// by default.
    /// </summary>
    public string? Id { get; set; } = null;
}
