using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Purchases;

public class PurchaseHandler(ILogger<PurchaseHandler> logger)
{
    public async Task<(List<Purchase> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetPurchase qry,
        [FromServices] IPurchaseService service,
        CancellationToken ct = default
    )
    {
        logger.LogInformation($"Fetching Purchases, PageIndex = {qry.PageIndex}, PageSize: {qry.PageSize}");
        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: false,
            cancellationToken: ct
        );
        return response.Value;
    }
}
