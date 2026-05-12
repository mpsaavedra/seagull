using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Warehouses;

public class WarehouseHandler(ILogger<WarehouseHandler> logger)
{
    public async Task<(List<WarehouseDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetWarehouse command,
        [FromServices] IWarehouseService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Warehousees, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);
        return (
            mapper.Map<List<WarehouseDto>>(response.Value.Data),
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<WarehouseDetailsDto?> Handle(
        GetByIdWarehouse command,
        [FromServices] IWarehouseService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Warehouse with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, false, cancellationToken);
        if (entity is null)
            return null;
        var entityDto = mapper.Map<WarehouseDetailsDto>(entity);
        return entityDto;
    }
}
