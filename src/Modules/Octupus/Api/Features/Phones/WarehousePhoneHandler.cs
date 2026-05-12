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
        logger.LogInformation($"Fetching WarehousePhonees, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);
        return (
            mapper.Map<List<WarehousePhoneDto>>(response.Value.Data),
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

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, false, cancellationToken);
        if (entity is null)
            return null;
        var entityDto = mapper.Map<WarehousePhoneDetailsDto>(entity);
        return entityDto;
    }
}
