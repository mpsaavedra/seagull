using System;
using Octupus.Api.Features.Categories;
using Octupus.Api.Features.Invoices;
using Octupus.Api.Features.MeasureUnits;
using Octupus.Api.Features.Moneys;
using Octupus.Contracts.Dtos;
using Seagull.Data;
using Seagull.Data.AutoMapping;
using Seagull.Exceptions;
using Seagull.Extensions;

namespace Octupus.Api.Features.Products;

public partial class Product : AuditableEntity, IMap<ProductDto>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string SKU { get; set; }
    public virtual ICollection<ProductImage> Images { get; set; } = [];
    public string? CategoryId { get; set; }
    public virtual Category? Category { get; set; }
    public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; } = [];
    /// <summary>
    /// Expiration date if any
    /// </summary>
    public DateTime? ExpirationDate { get; set; }
    public string CostId { get; set; }
    /// <summary>
    /// Purchase cost of this product
    /// </summary>
    public Money Cost { get; set; }
    public string MeasureUnitId { get; set; }
    public virtual MeasureUnit MeasureUnit { get; set; }

    #region Fields related with the status of the product

    /// <summary>
    /// Products in this list have been reciently purchased, this list is perhaps the list
    /// that will less products had
    /// </summary>
    public ICollection<PurchaseProduct> PurchaseProducts { get; set; } = [];
    public ICollection<PurchaseInvoiceProduct> PurchaseInvoiceProducts { get; set; } = [];
    /// <summary>
    /// gets the warehouse relation to the product, from this status the user could move
    /// poduct through the different status because is already registered in the system
    /// </summary>
    public ICollection<WarehouseProduct> WarehouseProducts { get; set; } = [];
    /// <summary>
    /// gets the relation to the product when the product has been transfer to an stand,
    /// this is one of the posible product status
    /// </summary>
    public ICollection<StandProduct> StandProducts { get; set; } = [];
    /// <summary>
    /// gets the relation to the product when the product has been directly sold from
    /// the warehouse
    /// </summary>
    public ICollection<SaleProduct> SaleProducts { get; set; } = [];

    #endregion

    public static Product Create(string name, string? sku = null, string? description = null, string? categoryId = null,
        DateTime? expirationDate = null) =>
        new()
        {
            Name = name,
            SKU = sku.IsNullEmptyOrWhiteSpace() ? Product.GenerateSKU(name) : sku!,
            Description = description,
            CategoryId = categoryId,
            ExpirationDate = expirationDate
        };

    public void UpdateProduct(string name, string? sku = null, string? description = null, string? categoryId = null,
        DateTime? expirationDate = null)
    {
        if (!string.IsNullOrEmpty(name))
        {
            Name = name;
        }

        if (!string.IsNullOrEmpty(sku))
        {
            SKU = sku;
        }
        if (!string.IsNullOrEmpty(description))
        {
            Description = description;
        }
        if (!string.IsNullOrEmpty(categoryId))
        {
            CategoryId = categoryId;
        }
        if (expirationDate is not null)
            ExpirationDate = expirationDate;
    }

    public void AddImage(ProductImage productImage)
    {
        if (!Images.Contains(productImage))
        {
            throw new SeagullException($"Product {Name} already has an image {productImage.ImageUrl}");
        }

        Images.Add(productImage);
    }

    public void RemoveImage(ProductImage productImage)
    {
        if (!Images.Contains(productImage))
        {
            throw new SeagullException($"Product {Name} doesn't has an image {productImage.ImageUrl}");
        }

        Images.Remove(productImage);
    }

    private static string GenerateSKU(string name)
    {
        // TODO: implement this in a more comprehensive way
        var luid = Ulid.NewUlid().ToString().Remove('-').Substring(0, 10);
        return $"SKU-{name.ToLower()}-{luid}";
    }
}

