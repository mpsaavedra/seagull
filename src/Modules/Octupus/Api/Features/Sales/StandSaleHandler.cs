using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Sales;

public class StandSaleHandler(ILogger<StandSaleHandler> logger)
{
    public async Task<(List<StandSaleDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetStandSale command,
        [FromServices] IStandSaleService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching StandSale, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<StandSaleDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} StandSale entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<StandSaleDetailsDto?> Handle(
        GetByIdStandSale command,
        [FromServices] IStandSaleService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching StandSale with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<StandSaleDetailsDto>(entity);

        logger.LogDebug($"Retrieving StandSale: {entityDto}");

        return entityDto;
    }
}
