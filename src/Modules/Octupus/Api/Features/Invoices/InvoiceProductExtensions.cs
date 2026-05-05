using System;
using JasperFx.Core.Reflection;
using Seagull;
using Seagull.Extensions;

namespace Octupus.Api.Features.Invoices;

public partial class InvoiceProduct
{
    public static Result<InvoiceProduct> Create(string productId, string invoiceId,
        string costId, string measureUnitId, decimal quantity, 
        string? description = null) =>
        Result
            .Create(new InvoiceProduct()
            {
                ProductId = productId,
                InvoiceId = invoiceId,
                CostId = costId,
                MeasureUnitId = measureUnitId,
                Quantity = quantity,
                Description = description
            });

    public Result Update(string? productId = null, string? invoiceId = null,
        string? costId = null, string? measureUnitId = null, 
        decimal? quantity = null, string? description = null) =>
        Result
            .Assign(this, !productId.IsNullEmptyOrWhiteSpace(), x => x.ProductId = productId!)
            .Assign(this, !invoiceId.IsNullEmptyOrWhiteSpace(), x => x.InvoiceId = invoiceId!)
            .Assign(this, !costId.IsNullEmptyOrWhiteSpace(), x => x.CostId = costId!)
            .Assign(this, !measureUnitId.IsNullEmptyOrWhiteSpace(), x => x.MeasureUnitId = measureUnitId!)
            .Assign(this, quantity.HasValue, x => x.Quantity = quantity!.Value)
            .Assign(this, !description.IsNullEmptyOrWhiteSpace(), x => x.Description = description!);
}
