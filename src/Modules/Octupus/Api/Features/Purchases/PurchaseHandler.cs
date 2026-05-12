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
        logger.LogInformation($"Fetching Purchasees, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);
        return (
            mapper.Map<List<PurchaseDto>>(response.Value.Data),
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

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, false, cancellationToken);
        if (entity is null)
            return null;
        var entityDto = mapper.Map<PurchaseDetailsDto>(entity);
        return entityDto;
    }
}
