using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Products;

public class SaleProductHandler(ILogger<SaleProductHandler> logger)
{
    public async Task<(List<SaleProduct> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetSaleProduct qry,
        [FromServices] ISaleProductService service,
        CancellationToken ct = default
    )
    {
        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: qry.SoftDeleted,
            cancellationToken: ct
        );
        return response.Value;
    }
}
