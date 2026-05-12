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
        logger.LogInformation($"Fetching ProductImagees, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);
        return (
            mapper.Map<List<ProductImageDto>>(response.Value.Data),
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

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, false, cancellationToken);
        if (entity is null)
            return null;
        var entityDto = mapper.Map<ProductImageDetailsDto>(entity);
        return entityDto;
    }
}
