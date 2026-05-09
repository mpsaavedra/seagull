using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Cities;

public class CityHandler(ILogger<CityHandler> logger)
{
    public async Task<(List<City> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
            GetCity command,
            [FromServices] ICityService service,
            CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Cities, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var entities = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        return entities.Value;
    }
}
