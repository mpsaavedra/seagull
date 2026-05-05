using System;
using Octupus.Api.Features.Products;
using Seagull;
using Seagull.Extensions;

namespace Octupus.Api.Features.Invoices;

public partial class PurchaseInvoice
{
    public static Result<PurchaseInvoice> Create(string purchaseId, string number,
        DateTime? date = null) =>
        Result
            .Create(new PurchaseInvoice()
            {
                PurchaseId = purchaseId,
                Number = number,
                Date = date.HasValue ? date.Value : DateTime.UtcNow
            });

    public Result Update(string? purchaseId = null, string? number = null,
        DateTime? date = null) =>
        Result
            .Assign(this, !purchaseId.IsNullEmptyOrWhiteSpace(), x => x.PurchaseId = purchaseId!)
            .Assign(this, !number.IsNullEmptyOrWhiteSpace(), x => x.Number = number!)
            .Assign(this, date.HasValue, x => x.Date = date!.Value);

    public Result AddProduct(PurchaseInvoiceProduct product) =>
        Result
            .Check(this, x => x.Products.Contains(product), ErrorCodes.OctupusApi.PurchaseInvoiceProductProductAlreadyExists)
            .Bind(this, x => x.Products.Add(product));

    public Result RemoveProduct(PurchaseInvoiceProduct product) =>
        Result
            .Check(this, x => !x.Products.Contains(product), ErrorCodes.OctupusApi.PurchaseInvoiceProductProductDoesNotExists)
            .Bind(this, x => x.Products.Remove(product));
}
