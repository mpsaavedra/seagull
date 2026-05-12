using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Cities;

public class CityHandler(ILogger<CityHandler> logger)
{
    public async Task<(List<CityDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetCity command,
        [FromServices] ICityService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Cityes, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);
        return (
            mapper.Map<List<CityDto>>(response.Value.Data),
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<CityDetailsDto?> Handle(
        GetByIdCity command,
        [FromServices] ICityService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching City with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, false, cancellationToken);
        if (entity is null)
            return null;
        var entityDto = mapper.Map<CityDetailsDto>(entity);
        return entityDto;
    }
}
