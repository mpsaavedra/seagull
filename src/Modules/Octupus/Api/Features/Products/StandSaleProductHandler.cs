using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Products;

public class StandSaleProductHandler(ILogger<StandSaleProductHandler> logger)
{
    public async Task<(List<StandSaleProduct> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetStandSaleProduct qry,
        [FromServices] IStandSaleProductService service,
        CancellationToken ct = default
    )
    {
        logger.LogInformation($"Fetching StandSaleProducts PageIndex: {qry.PageIndex}, PageSize: {qry.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: qry.SoftDeleted,
            cancellationToken: ct
        );
        return response.Value;
    }
}
