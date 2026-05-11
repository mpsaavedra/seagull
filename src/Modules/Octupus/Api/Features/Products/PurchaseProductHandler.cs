using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Products;

public class PurchaseProductHandler(ILogger<PurchaseProductHandler> logger)
{
    public async Task<(List<PurchaseProduct> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetPurchaseProduct qry,
        [FromServices] IPurchaseProductService service,
        CancellationToken ct = default
    )
    {
        logger.LogInformation($"Fetching PurchaseProducts, PageIndex: {qry.PageIndex}, PageSize: {qry.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: qry.SoftDeleted,
            cancellationToken: ct
        );
        return response.Value;
    }
}
