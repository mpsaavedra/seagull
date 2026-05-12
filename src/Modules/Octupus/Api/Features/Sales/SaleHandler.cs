using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Sales;

public class SaleHandler(ILogger<SaleHandler> logger)
{
    public async Task<(List<SaleDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetSale command,
        [FromServices] ISaleService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Sale, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<SaleDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} Sale entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<SaleDetailsDto?> Handle(
        GetByIdSale command,
        [FromServices] ISaleService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Sale with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<SaleDetailsDto>(entity);

        logger.LogDebug($"Retrieving Sale: {entityDto}");

        return entityDto;
    }
}
