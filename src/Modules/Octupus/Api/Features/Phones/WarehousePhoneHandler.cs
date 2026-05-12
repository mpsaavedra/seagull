using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Phones;

public class WarehousePhoneHandler(ILogger<WarehousePhoneHandler> logger)
{
    public async Task<(List<WarehousePhoneDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetWarehousePhone command,
        [FromServices] IWarehousePhoneService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching WarehousePhone, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<WarehousePhoneDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} WarehousePhone entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<WarehousePhoneDetailsDto?> Handle(
        GetByIdWarehousePhone command,
        [FromServices] IWarehousePhoneService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching WarehousePhone with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<WarehousePhoneDetailsDto>(entity);

        logger.LogDebug($"Retrieving WarehousePhone: {entityDto}");

        return entityDto;
    }
}
