using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Phones;

public class StandPhoneHandler(ILogger<StandPhoneHandler> logger)
{
    public async Task<(List<StandPhoneDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetStandPhone command,
        [FromServices] IStandPhoneService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching StandPhone, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<StandPhoneDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} StandPhone entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<StandPhoneDetailsDto?> Handle(
        GetByIdStandPhone command,
        [FromServices] IStandPhoneService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching StandPhone with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<StandPhoneDetailsDto>(entity);

        logger.LogDebug($"Retrieving StandPhone: {entityDto}");

        return entityDto;
    }
}
