using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Products;

public class ProductImageHandler(ILogger<ProductImageHandler> logger)
{
    public async Task<(List<ProductImage> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetProductImage qry,
        [FromServices] IProductImageService service,
        CancellationToken ct = default
    )
    {
        logger.LogInformation($"Fetching ProductImages, PageIndex: {qry.PageIndex}, PageSize: {qry.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: qry.SoftDeleted,
            cancellationToken: ct
        );
        return response.Value;
    }
}
