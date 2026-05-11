using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Products;

public class WarehouseProductHandler(ILogger<WarehouseProductHandler> logger)
{
    public async Task<(List<WarehouseProduct> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetWarehouseProduct qry,
        [FromServices] IWarehouseProductService service,
        CancellationToken ct = default
    )
    {
        logger.LogInformation($"Fetching WarehouseProducts, PageIndex: {qry.PageIndex}, PageSize: {qry.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: qry.SoftDeleted,
            cancellationToken: ct
        );
        return response.Value;
    }
}
