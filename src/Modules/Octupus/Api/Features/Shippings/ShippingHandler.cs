using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Shippings;

public class ShippingHandler(ILogger<Shipping> logger)
{
    public async Task<(List<Shipping> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetShiping qry,
        [FromServices] IShippingService service,
        CancellationToken ct = default
    )
    {
        logger.LogInformation($"Fetching Shippings, PAgeIndex: {qry.PageIndex}, PageSize: {qry.PageSize}");
        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: false,
            cancellationToken: ct
        );
        return response.Value;
    }
}
