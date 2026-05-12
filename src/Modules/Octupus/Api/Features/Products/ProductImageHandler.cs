using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Products;

public class ProductImageHandler(ILogger<ProductImageHandler> logger)
{
    public async Task<(List<ProductImageDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetProductImage command,
        [FromServices] IProductImageService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching ProductImage, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<ProductImageDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} ProductImage entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<ProductImageDetailsDto?> Handle(
        GetByIdProductImage command,
        [FromServices] IProductImageService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching ProductImage with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<ProductImageDetailsDto>(entity);

        logger.LogDebug($"Retrieving ProductImage: {entityDto}");

        return entityDto;
    }
}
