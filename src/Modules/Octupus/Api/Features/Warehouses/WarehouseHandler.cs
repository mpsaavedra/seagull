using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Warehouses;

public class WarehouseHandler(ILogger<WarehouseHandler> logger)
{
    public async Task<(List<Warehouse> Data, bool HasPerviousPage, bool HasNextPage)> Handle(
        GetWarehouse command,
        [FromServices] IWarehouseService service,
        CancellationToken ct = default)
    {
        logger.LogInformation($"Fetching Warehouses: PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");
        var entities = await service.GetAllAsync(
            pageIndex: command.PageIndex,
            pageSize: command.PageSize,
            includeSoftDeleted: false,
            cancellationToken: ct
        );
        return entities.Value;
    }
}
