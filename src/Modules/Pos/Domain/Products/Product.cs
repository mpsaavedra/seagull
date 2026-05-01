using System.ComponentModel.DataAnnotations.Schema;
using Pos.Domain.Categories;
using Pos.Domain.Invoices;
using Pos.Domain.MeasureUnits;
using Pos.Domain.Moneys;
using Pos.Domain.Purchases;
using Pos.Domain.Warehouses;
using Seagull.Data;
using Seagull.Data.ValueObjects;
using Seagull.Exceptions;

namespace Pos.Domain.Products;

public partial class Product : AuditableEntity
{
    protected Product() : base()
    {
        Images = [];
        InvoiceProducts = [];
        PurchaseProducts = [];
        WarehouseProducts = [];
    }
    public Product(string name, string? sku = null, string? description = null, string? categoryId = null, 
        DateTime? expirationDate = null)
    {
        Name = name;
        Description = description;
        CategoryId = categoryId;
        SKU = !string.IsNullOrEmpty(sku) ? sku : GenerateSKU();
        ExpirationDate = expirationDate is not null ? expirationDate : ExpirationDate;
    }

    public string Name { get; protected set; }
    public string? Description { get; protected set; }
    public string SKU { get; protected set; }
    public virtual ICollection<ProductImage> Images { get; protected set; }
    public string? CategoryId { get; protected set; }
    public virtual Category? Category { get; protected set; }
    public virtual ICollection<InvoiceProduct> InvoiceProducts { get; protected set; }
    /// <summary>
    /// Expiration date if any
    /// </summary>
    public DateTime? ExpirationDate { get; protected set; }
    public string CostId { get; set; }
    /// <summary>
    /// Purchase cost of this product
    /// </summary>
    public Money Cost { get; protected set;}
    public string MeasureUnitId { get; set; }
    public virtual MeasureUnit MeasureUnit { get; protected set; }

    #region Fields related with the status of the product

    /// <summary>
    /// Products in this list have been reciently purchased, this list is perhaps the list
    /// that will less products had
    /// </summary>
    public ICollection<PurchaseProduct> PurchaseProducts { get; protected set; }
    public ICollection<PurchaseInvoiceProduct> PurchaseInvoiceProducts { get; protected set; }
    /// <summary>
    /// gets the warehouse relation to the product, from this status the user could move
    /// poduct through the different status because is already registered in the system
    /// </summary>
    public ICollection<WarehouseProduct> WarehouseProducts { get; protected set; }
    /// <summary>
    /// gets the relation to the product when the product has been transfer to an stand,
    /// this is one of the posible product status
    /// </summary>
    public ICollection<StandProduct> StandProducts { get; protected set; }
    /// <summary>
    /// gets the relation to the product when the product has been directly sold from
    /// the warehouse
    /// </summary>
    public ICollection<SaleProduct> SaleProducts { get; protected set; }

    #endregion

    public static Product Create(string name, string? sku = null, string? description = null, string? categoryId = null, 
        DateTime? expirationDate = null) =>
        new(name, sku, description, categoryId, expirationDate);

    public void UpdateProduct(string name, string? sku = null, string? description = null, string? categoryId = null, 
        DateTime? expirationDate = null)
    {
        if(!string.IsNullOrEmpty(name))
        {
            Name = name;
        }

        if(!string.IsNullOrEmpty(sku))
        {
            SKU = sku;
        }
        if(!string.IsNullOrEmpty(description))
        {
            Description = description;
        }
        if(!string.IsNullOrEmpty(categoryId))
        {
            CategoryId = categoryId;
        }
        if(expirationDate is not null)
            ExpirationDate = expirationDate;
    }

    public void AddImage(ProductImage productImage)
    {
        if(!Images.Contains(productImage))
        {
            throw new SeagullException($"Product {Name} already has an image {productImage.ImageUrl}");
        }

        Images.Add(productImage);
    }

    public void RemoveImage(ProductImage productImage)
    {
        if(!Images.Contains(productImage))
        {
            throw new SeagullException($"Product {Name} doesn't has an image {productImage.ImageUrl}");
        }

        Images.Remove(productImage);
    }

    private string GenerateSKU()
    {
        // TODO: implement this in a more comprehensive way
        var luid = Ulid.NewUlid().ToString().Remove('-').Substring(0, 10);
        return $"SKU-{Name.ToLower()}-{luid}";
    }
}
