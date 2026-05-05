using System;
using Octupus.Api.Features.Products;
using Seagull.Data;
using Seagull.Extensions;

namespace Octupus.Api.Features.Categories;

/// <summary>
/// Category in which a product could be group by, this entity allows to create a relation between
/// parent and child categories.
/// </summary>
public partial class Category : AuditableEntity
{
    /// <summary>
    /// name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// short code to refer to the category
    /// </summary>
    public string Code { get; set; }
    /// <summary>
    /// textile, tools, etc.
    /// </summary>
    public string? Type { get; set; }
    /// <summary>
    /// description
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// gets/sets the parent category id if any
    /// </summary>
    public string? ParentCategoryId { get; set; }
    /// <summary>
    /// gets/sets the parent category if any
    /// </summary>
    public virtual Category? ParentCategory { get; set; }
    /// <summary>
    /// gets/set the child categories if any for this category
    /// </summary>
    public virtual ICollection<Category> ChildCategories {  get; set; } = [];
    /// <summary>
    /// products in this category
    /// </summary>
    public virtual ICollection<Product> Products { get; set; } = [];
}
