using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Phones;

public class StandPhoneHandler(ILogger<StandPhoneHandler> logger)
{
    public async Task<(List<StandPhone> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetStandPhone qry,
        [FromServices] IStandPhoneService service,
        CancellationToken ct = default
    )
    {
        logger.LogInformation($"Fetching StandPhones PageIndex: {qry.PageIndex}, PageSize: {qry.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: false,
            cancellationToken: ct
        );
        return response.Value;
    }
}
