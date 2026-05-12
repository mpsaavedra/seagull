using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Products;

public class PurchaseProductHandler(ILogger<PurchaseProductHandler> logger)
{
    public async Task<(List<PurchaseProductDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetPurchaseProduct command,
        [FromServices] IPurchaseProductService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching PurchaseProductes, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);
        return (
            mapper.Map<List<PurchaseProductDto>>(response.Value.Data),
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<PurchaseProductDetailsDto?> Handle(
        GetByIdPurchaseProduct command,
        [FromServices] IPurchaseProductService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching PurchaseProduct with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, false, cancellationToken);
        if (entity is null)
            return null;
        var entityDto = mapper.Map<PurchaseProductDetailsDto>(entity);
        return entityDto;
    }
}
