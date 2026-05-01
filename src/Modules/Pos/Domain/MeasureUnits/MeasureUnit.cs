using System;
using Pos.Domain.Invoices;
using Pos.Domain.Products;
using Seagull.Data;
using Seagull.Extensions;

namespace Pos.Domain.MeasureUnits;

public partial class MeasureUnit : AuditableEntity
{
    protected MeasureUnit()
    {
        Products = [];
        PurchaseInvoiceProducts = [];
        InvoiceProducts = [];
    }

    public MeasureUnit(string name, string? symbol = null)
    {
        Name = name;
        Symbol = !symbol!.IsNullEmptyOrWhiteSpace() 
            ? symbol 
            : symbol!.RemoveVocals()[..5];
    }

    public string Name { get; set; }
    public string? Symbol { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
    public ICollection<PurchaseInvoiceProduct> PurchaseInvoiceProducts { get; set; }

    public static MeasureUnit Create(string name, string? symbol) =>
        new(name, symbol);
}
