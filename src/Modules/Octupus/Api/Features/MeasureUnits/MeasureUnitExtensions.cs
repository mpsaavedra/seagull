using System;
using Octupus.Api.Features.Invoices;
using Octupus.Api.Features.Products;
using Seagull;
using Seagull.Extensions;

namespace Octupus.Api.Features.MeasureUnits;

public partial class MeasureUnit
{
    public static MeasureUnit Create(string name, string? symbol = null) =>
        new MeasureUnit()
        {
            Name = name,
            Symbol = !symbol.IsNullEmptyOrWhiteSpace() ? symbol : symbol!.RemoveVocals()[..5]
        };

    public Result Update(string? name = null, string? symbol = null) =>
        Result
            .Assign(this, !name.IsNullEmptyOrWhiteSpace(), x => x.Name = name!)
            .Assign(this, !symbol.IsNullEmptyOrWhiteSpace(), x => x.Symbol = symbol);

    public Result AddProduct(Product product) =>
        Result
            .Check(this, x => x.Products.Contains(product), ErrorCodes.OctupusApi.MeasureUnitProductAlreadyExists)
            .Bind(this, x => x.Products.Add(product));

    public Result RemoveProduct(Product product) =>
        Result
            .Check(this, x => !x.Products.Contains(product), ErrorCodes.OctupusApi.MeasureUnitInvoiceProductDoesNotExists)
            .Bind(this, x => x.Products.Remove(product));

    public Result AddInvoiceProduct(InvoiceProduct product) =>
        Result
            .Check(this, x => x.InvoiceProducts.Contains(product), ErrorCodes.OctupusApi.MeasureUnitInvoiceProductAlreadyExists)
            .Bind(this, x => x.InvoiceProducts.Add(product));

    public Result RemoveInvoiceProduct(InvoiceProduct product) =>
        Result
            .Check(this, x => x.InvoiceProducts.Contains(product), ErrorCodes.OctupusApi.MeasureUnitInvoiceProductDoesNotExists)
            .Bind(this, x => x.InvoiceProducts.Remove(product));

    public Result AddPurchaseInvoiceProduct(PurchaseInvoiceProduct product) =>
        Result
            .Check(this, x => x.PurchaseInvoiceProducts.Contains(product), ErrorCodes.OctupusApi.MeasureUnitPurchaseInvoiceProductAlreadyExists)
            .Bind(this, x => x.PurchaseInvoiceProducts.Add(product));

    public Result RemovePurchaseInvoiceProduct(PurchaseInvoiceProduct product) =>
        Result
            .Check(this, x => x.PurchaseInvoiceProducts.Contains(product), ErrorCodes.OctupusApi.MeasureUnitPurchaseInvoiceProductDoesNotExists)
            .Bind(this, x => x.PurchaseInvoiceProducts.Remove(product));
}
