using System;

namespace Seagull.Abstractions.Requests;

/// <summary>
/// base for all queries.
/// </summary>
public record QueryBase
{
    /// <summary>
    /// do not include softdeleted valued by default
    /// </summary>
    public bool SoftDeleted { get; set; } = false;
}
