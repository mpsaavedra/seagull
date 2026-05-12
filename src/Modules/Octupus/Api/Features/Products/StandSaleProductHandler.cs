using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Products;

public class StandSaleProductHandler(ILogger<StandSaleProductHandler> logger)
{
    public async Task<(List<StandSaleProductDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetStandSaleProduct command,
        [FromServices] IStandSaleProductService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching StandSaleProduct, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<StandSaleProductDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} StandSaleProduct entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<StandSaleProductDetailsDto?> Handle(
        GetByIdStandSaleProduct command,
        [FromServices] IStandSaleProductService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching StandSaleProduct with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<StandSaleProductDetailsDto>(entity);

        logger.LogDebug($"Retrieving StandSaleProduct: {entityDto}");

        return entityDto;
    }
}
