using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Products;

public class StandProductHandler(ILogger<StandProductHandler> logger)
{
    public async Task<(List<StandProduct> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetStandProduct qry,
        [FromServices] IStandProductService service,
        CancellationToken ct = default
    )
    {
        logger.LogInformation($"Fetching StandProducts PageIndex: {qry.PageIndex}, PageSize: {qry.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: qry.SoftDeleted,
            cancellationToken: ct
        );
        return response.Value;
    }
}
