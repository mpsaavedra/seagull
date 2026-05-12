using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Products;

public class WarehouseProductHandler(ILogger<WarehouseProductHandler> logger)
{
    public async Task<(List<WarehouseProductDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetWarehouseProduct command,
        [FromServices] IWarehouseProductService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching WarehouseProduct, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<WarehouseProductDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} WarehouseProduct entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<WarehouseProductDetailsDto?> Handle(
        GetByIdWarehouseProduct command,
        [FromServices] IWarehouseProductService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching WarehouseProduct with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<WarehouseProductDetailsDto>(entity);

        logger.LogDebug($"Retrieving WarehouseProduct: {entityDto}");

        return entityDto;
    }
}
