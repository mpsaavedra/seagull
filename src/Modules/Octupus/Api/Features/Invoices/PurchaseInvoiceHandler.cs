using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Invoices;

public class PurchaseInvoiceHandler(ILogger<PurchaseInvoiceHandler> logger)
{
    public async Task<(List<PurchaseInvoice> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetPurchaseInvoice qry,
        [FromServices] IPurchaseInvoiceService service,
        CancellationToken ct = default
    )
    {
        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: false,
            cancellationToken: ct
        );
        return response.Value;
    }
}
