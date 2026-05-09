using System;
using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record ProductImageDto : DtoBase
{
    public string ImageUrl { get; set; }
    public int? Order { get; set; } = -1;
    public ProductDto Product { get; set; }
    public string? Alt { get; set; }
}


public sealed record ProductImageDetailsDto : DtoBase
{
    public string ImageUrl { get; set; }
    public int? Order { get; set; } = -1;
    public ProductDto Product { get; set; }
    public string? Alt { get; set; }
}
