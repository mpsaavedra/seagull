using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Phones;

public class SupplierPhoneHandler(ILogger<SupplierPhoneHandler> logger)
{
    public async Task<(List<SupplierPhone> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetSupplierPhone qry,
        [FromServices] ISupplierPhoneService service,
        CancellationToken ct = default
    )
    {
        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: false,
            cancellationToken: ct
        );
        return response.Value;
    }
}
