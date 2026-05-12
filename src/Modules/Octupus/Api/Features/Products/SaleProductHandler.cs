using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Products;

public class SaleProductHandler(ILogger<SaleProductHandler> logger)
{
    public async Task<(List<SaleProductDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetSaleProduct command,
        [FromServices] ISaleProductService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching SaleProduct, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<SaleProductDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} SaleProduct entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<SaleProductDetailsDto?> Handle(
        GetByIdSaleProduct command,
        [FromServices] ISaleProductService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching SaleProduct with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<SaleProductDetailsDto>(entity);

        logger.LogDebug($"Retrieving SaleProduct: {entityDto}");

        return entityDto;
    }
}
