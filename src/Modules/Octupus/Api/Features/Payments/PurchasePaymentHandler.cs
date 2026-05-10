using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Payments;

public class PurchasePaymentHandler(ILogger<PurchasePaymentHandler> logger)
{
    public async Task<(List<PurchasePayment> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetPurchasePayment qry,
        [FromServices] IPurchasePaymentService service,
        CancellationToken ct = default
    )
    {
        logger.LogInformation($"Fetching PurchasePayments, PageIndex: {qry.PageIndex}, PageSize: {qry.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: false,
            cancellationToken: ct
        );
        return response.Value;
    }
}
