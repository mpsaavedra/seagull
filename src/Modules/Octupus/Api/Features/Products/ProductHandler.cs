using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Products;

public class ProductHandler(ILogger<ProductHandler> logger)
{
    public async Task<(List<ProductDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetProduct command,
        [FromServices] IProductService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Product, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<ProductDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} Product entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<ProductDetailsDto?> Handle(
        GetByIdProduct command,
        [FromServices] IProductService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Product with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<ProductDetailsDto>(entity);

        logger.LogDebug($"Retrieving Product: {entityDto}");

        return entityDto;
    }
}
