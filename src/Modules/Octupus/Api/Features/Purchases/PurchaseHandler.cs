using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Purchases;

public class PurchaseHandler(ILogger<PurchaseHandler> logger)
{
    public async Task<(List<PurchaseDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetPurchase command,
        [FromServices] IPurchaseService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Purchase, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<PurchaseDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} Purchase entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<PurchaseDetailsDto?> Handle(
        GetByIdPurchase command,
        [FromServices] IPurchaseService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Purchase with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<PurchaseDetailsDto>(entity);

        logger.LogDebug($"Retrieving Purchase: {entityDto}");

        return entityDto;
    }
}
