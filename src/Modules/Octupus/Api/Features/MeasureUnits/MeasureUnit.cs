using System;
using Octupus.Api.Features.Invoices;
using Octupus.Api.Features.Products;
using Octupus.Contracts.Dtos;
using Seagull.Data;
using Seagull.Data.AutoMapping;
using Seagull.Extensions;

namespace Octupus.Api.Features.MeasureUnits;

public partial class MeasureUnit : AuditableEntity, IMap<MeasureUnitDto>
{
    private string _symbol;

    public string Name { get; set; }
    public string? Symbol
    {
        get => _symbol;
        set => _symbol = value.IsNullEmptyOrWhiteSpace()
            ? value!
            : value!.RemoveVocals().GetStringUpto(5);
    }
    public ICollection<Product> Products { get; set; } = [];
    public ICollection<InvoiceProduct> InvoiceProducts { get; set; } = [];
    public ICollection<PurchaseInvoiceProduct> PurchaseInvoiceProducts { get; set; } = [];
}
