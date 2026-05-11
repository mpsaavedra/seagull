using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Products;

public class ProductHandler(ILogger<ProductHandler> logger)
{
    public async Task<(List<Product> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetProduct qry,
        [FromServices] IProductService service,
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
