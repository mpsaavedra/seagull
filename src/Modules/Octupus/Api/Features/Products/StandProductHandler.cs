using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Products;

public class StandProductHandler(ILogger<StandProductHandler> logger)
{
    public async Task<(List<StandProductDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetStandProduct command,
        [FromServices] IStandProductService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching StandProduct, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<StandProductDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} StandProduct entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<StandProductDetailsDto?> Handle(
        GetByIdStandProduct command,
        [FromServices] IStandProductService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching StandProduct with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<StandProductDetailsDto>(entity);

        logger.LogDebug($"Retrieving StandProduct: {entityDto}");

        return entityDto;
    }
}
