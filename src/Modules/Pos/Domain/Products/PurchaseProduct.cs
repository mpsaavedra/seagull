using System;
using System.ComponentModel.DataAnnotations.Schema;
using Pos.Domain.Moneys;
using Pos.Domain.Purchases;
using Pos.Domain.Suppliers;
using Pos.Domain.Warehouses;
using Seagull.Data;
using Seagull.Data.ValueObjects;

namespace Pos.Domain.Products;

/// <summary>
/// relation of product and purchase
/// </summary>
public partial class PurchaseProduct : AuditableEntity
{
    protected PurchaseProduct()
    {
        
    }

    /// <summary>
    /// id of purchased product
    /// </summary>
    public string ProductId { get; set; }
    /// <summary>
    /// purchased product
    /// </summary>
    public virtual Product Product { get; set; }
    /// <summary>
    /// purchase date of product if null purchase date is used
    /// </summary>
    public DateTime? Date { get; set; }
    /// <summary>
    /// Due date 
    /// </summary>
    public DateTime? DueDate { get; set; }
    /// <summary>
    /// purchase id
    /// </summary>
    public string PurchaseId { get; set; }
    /// <summary>
    /// related purchase
    /// </summary>
    public virtual Purchase Purchase { get; set; }
    /// <summary>
    /// quantity of acquired products
    /// </summary>
    public decimal Quantity { get; set; }
    public string MoneyId { get; set; }
    public string PurchasePriceId { get; set; }
    /// <summary>
    /// Price of the products at purchase moment
    /// </summary>
    public Money PurchasePrice { get; set; }
    /// <summary>
    /// any additional detail
    /// </summary>
    public string? Details { get; set; }
    /// <summary>
    /// supplier id
    /// </summary>
    public string? SupplierId { get; set; }
    /// <summary>
    /// Supplier to which the product was bough to if null use the purchase Supplier
    /// </summary>
    public virtual Supplier? Supplier { get; set; }
    /// <summary>
    /// real cost of the product purchase
    /// </summary>
    [NotMapped] 
    public Money Cost => Money.Create(Quantity * PurchasePrice.Amount, PurchasePrice.Currency.Name);
}
