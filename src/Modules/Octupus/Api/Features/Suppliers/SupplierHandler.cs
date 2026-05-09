using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Suppliers;

public class SupplierHandler(ILogger<SupplierHandler> logger)
{
    public async Task<(List<Supplier> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetSupplier qry,
        [FromServices] ISupplierService service,
        CancellationToken ct = default
    )
    {
        logger.LogInformation($"Fetching Suppliers, PageIndex {qry.PageIndex}, PageSize: {qry.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: false,
            cancellationToken: ct
        );
        return response.Value;
    }
}
