using System;

namespace Seagull.Abstractions.Requests;

/// <summary>
/// base query to be used when a paginated result is expected
/// </summary>
public record PaginatedQueryBase : QueryBase
{
    /// <summary>
    /// index of page to return
    /// </summary>
    public int PageIndex { get; set; } = 1;
    /// <summary>
    /// size of data page to return
    /// </summary>
    public int PageSize { get; set; } = 50;
}
