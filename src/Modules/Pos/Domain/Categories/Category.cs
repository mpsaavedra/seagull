using System;
using Pos.Contracts.Events;
using Pos.Domain.Products;
using Seagull.Data;
using Seagull.Exceptions;
using Seagull.Extensions;

namespace Pos.Domain.Categories;

/// <summary>
/// Category in which a product could be group by, this entity allows to create a relation between
/// parent and child categories.
/// </summary>
public partial class Category : AuditableEntity
{
    protected Category() : base()
    {
        ChildCategories = new HashSet<Category>();
        Products = new HashSet<Product>();
    }
    public Category(string name, string? code, string? description = null, string? parentCategoryId = null, string? type = null)
    {
        Name = name;
        Description = description;
        ParentCategoryId = parentCategoryId;
        Type = type;
        Code = code!;
    }

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
    public virtual ICollection<Category> ChildCategories {  get; set; }
    /// <summary>
    /// products in this category
    /// </summary>
    public virtual ICollection<Product> Products { get; set; }

    /// <summary>
    /// returns a new <see cref="Category"/> instance
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="parentCategoryId"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static Category Create(string name, string? code = null, string? description = null, string? parentCategoryId = null, string? type = null) =>
        new(name, code, description, parentCategoryId, type);

    /// <summary>
    /// updates current category instance
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="parentCategoryId"></param>
    /// <param name="type"></param>
    public void UpdateCategory(string? name = null, string? code = null, string? description = null, string? parentCategoryId = null, string? type = null)
    {
        Name = name.UpdateIfDifferent(Name);
        Code = code.UpdateIfDifferent(Code);
        Description = description.UpdateIfDifferent(Description!);
        ParentCategoryId = parentCategoryId.UpdateIfDifferent(ParentCategoryId!);
        Type = type.UpdateIfDifferent(type!);
    }
}
