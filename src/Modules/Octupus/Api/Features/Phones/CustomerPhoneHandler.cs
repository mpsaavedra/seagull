using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Phones;

public class CustomerPhoneHandler(ILogger<CustomerPhoneHandler> logger)
{
    public async Task<(List<CustomerPhone> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetCustomerPhone qry,
        [FromServices] ICustomerPhoneService service,
        CancellationToken ct = default
    )
    {
        logger.LogInformation($"Fetching CustomerPhones, PageIndex {qry.PageIndex}, PageSize: {qry.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: qry.SoftDeleted,
            cancellationToken: ct
        );
        return response.Value;
    }
}
