using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record CategoryDto : DtoBase
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
    public CategoryDto? ParentCategory { get; set; } = null;
}

public sealed record CategoryDetailsDto : DtoBase
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
    public CategoryDto? ParentCategory { get; set; }
    public ICollection<CategoryDto> ChildCategories { get; set; } = [];
    public ICollection<ProductDto> Products { get; set; } = [];
}