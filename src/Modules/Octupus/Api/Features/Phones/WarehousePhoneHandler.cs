using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Phones;

public class WarehousePhoneHandler(ILogger<WarehousePhoneHandler> logger)
{
    public async Task<(List<WarehousePhone> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetWarehousePhone qry,
        [FromServices] IWarehousePhoneService service,
        CancellationToken ct = default
    )
    {
        logger.LogInformation($"Fetching WarehousePhones, PageIndex: {qry.PageIndex}, PageSize: {qry.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: false,
            cancellationToken: ct
        );
        return response.Value;
    }
}
