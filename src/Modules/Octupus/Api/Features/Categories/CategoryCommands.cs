using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Categories;

public sealed record CreateCategory : IMap<Category>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
    public string? ParentCategoryId { get; set; }
}
public sealed record UpdateAddress : IMap<Category>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
    public string? ParentCategoryId { get; set; }
}
public sealed record DeleteCategory
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}
