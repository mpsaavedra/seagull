using System;
using Octupus.Api.Features.Products;
using Seagull;
using Seagull.Extensions;

namespace Octupus.Api.Features.Categories;

public partial class Category
{
    /// <summary>
    /// returns a new <see cref="Category"/> instance
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="parentCategoryId"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static Result<Category> Create( string name, string code, string? type = null, 
        string? description = null, string? parentCategoryId = null) =>
        Result
            .Create(new Category (){
            Name = name, 
            Code = code, 
            Description = description, 
            ParentCategoryId = parentCategoryId, 
            Type = type
        });

    public Result Update(string? name = null, string? code = null, 
        string? description = null, string? parentCategoryId = null, string? type = null) =>
        Result
            .Assign(this, !!name.IsNullEmptyOrWhiteSpace(), x => x.Name = name!)
            .Assign(this, !code.IsNullEmptyOrWhiteSpace(), x => x.Code = code!)
            .Assign(this, !description.IsNullEmptyOrWhiteSpace(), x => x.Description = description)
            .Assign(this, !parentCategoryId.IsNullEmptyOrWhiteSpace(), x => x.ParentCategoryId = parentCategoryId)
            .Assign(this, !type.IsNullEmptyOrWhiteSpace(), x=> x.Type = type);

    public Result AddChildCategory(Category category) =>
        Result
            .Check(this, x => x.ChildCategories.Contains(category), ErrorCodes.OctupusApi.CategoryChildCategoryAlreadyExists)
            .Bind(this, x => x.ChildCategories.Add(category));

    public Result RemoveChildCategory(Category category) =>
        Result
            .Check(this, x => x.ChildCategories.Contains(category), ErrorCodes.OctupusApi.CategoryChildCategoryDoesNotExists)
            .Bind(this, x => x.ChildCategories.Add(category));

    public Result AddProduct(Product product) =>
        Result
            .Check(this, x => x.Products.Contains(product), ErrorCodes.OctupusApi.CategoryProductExists)
            .Bind(this, x => x.Products.Add(product));

    public Result RemoveProduct(Product product) =>
        Result
            .Check(this, x => !x.Products.Contains(product), ErrorCodes.OctupusApi.CategoryProductDoesNotExists)
            .Bind(this, x => x.Products.Remove(product));

}
