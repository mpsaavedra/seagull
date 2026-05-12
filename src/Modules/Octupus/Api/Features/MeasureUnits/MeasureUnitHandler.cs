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
        logger.LogInformation($"Fetching MeasureUnites, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);
        return (
            mapper.Map<List<MeasureUnitDto>>(response.Value.Data),
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

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, false, cancellationToken);
        if (entity is null)
            return null;
        var entityDto = mapper.Map<MeasureUnitDetailsDto>(entity);
        return entityDto;
    }
}
