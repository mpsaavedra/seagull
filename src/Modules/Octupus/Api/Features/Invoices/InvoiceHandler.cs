using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Invoices;

public class InvoiceHandler(ILogger<InvoiceHandler> logger)
{
    public async Task<(List<Invoice> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetInvoice qry,
        [FromServices] IInvoiceService service,
        CancellationToken ct = default
    )
    {
        logger.LogInformation($"Fetching Invoices, PageIndex {qry.PageIndex}, PageSize {qry.PageSize}");
        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: false,
            cancellationToken: ct
        );
        return response.Value;
    }
}
