using System;
using Octupus.Api.Features.Invoices;
using Octupus.Api.Features.Products;
using Seagull.Data;
using Seagull.Extensions;

namespace Octupus.Api.Features.MeasureUnits;

public partial class MeasureUnit : AuditableEntity
{
    private string _symbol;

    public string Name { get; set; }
    public string? Symbol 
    { 
        get => _symbol;
        set => _symbol = value.IsNullEmptyOrWhiteSpace() 
            ? value! 
            : value!.RemoveVocals()[..5];
    }
    public ICollection<Product> Products { get; set; } = [];
    public ICollection<InvoiceProduct> InvoiceProducts { get; set; } = [];
    public ICollection<PurchaseInvoiceProduct> PurchaseInvoiceProducts { get; set; } = [];
}
