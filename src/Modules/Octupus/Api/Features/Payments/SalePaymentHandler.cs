using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Payments;

public class SalePaymentHandler(ILogger<SalePaymentHandler> logger)
{
    public async Task<(List<SalePayment> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetSalePayment qry,
        [FromServices] ISalePaymentService service,
        CancellationToken ct = default
    )
    {
        logger.LogInformation($"Fetching SalePayments PageIndex: {qry.PageIndex}, PageSize: {qry.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: false,
            cancellationToken: ct
        );
        return response.Value;
    }
}
