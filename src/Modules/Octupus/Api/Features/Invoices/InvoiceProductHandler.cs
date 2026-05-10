using System;

namespace Octupus.Api.Features.Invoices;

public class InvoiceProductHandler(ILogger<InvoiceProductHandler> logger)
{
    public async Task<(List<InvoiceProduct> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetInvoiceProduct qry,
        [FromKeyedServices] IInvoiceProductService service,
        CancellationToken ct = default
    )
    {
        logger.LogInformation($"Fetching InvoiceProducts, PageIndex {qry.PageIndex}, pageSize {qry.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: false,
            cancellationToken: ct
        );
        return response.Value;
    }
}
