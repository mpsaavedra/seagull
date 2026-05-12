using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.MeasureUnits;

public class MeasureUnitHandler(ILogger<MeasureUnitHandler> logger)
{
    public async Task<(List<MeasureUnitDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetMeasureUnit command,
        [FromServices] IMeasureUnitService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching MeasureUnit, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<MeasureUnitDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} MeasureUnit entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<MeasureUnitDetailsDto?> Handle(
        GetByIdMeasureUnit command,
        [FromServices] IMeasureUnitService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching MeasureUnit with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<MeasureUnitDetailsDto>(entity);

        logger.LogDebug($"Retrieving MeasureUnit: {entityDto}");

        return entityDto;
    }
}
