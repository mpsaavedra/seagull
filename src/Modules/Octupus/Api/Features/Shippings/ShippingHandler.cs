using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Shippings;

public class ShippingHandler(ILogger<ShippingHandler> logger)
{
    public async Task<(List<ShippingDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetShipping command,
        [FromServices] IShippingService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Shipping, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<ShippingDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} Shipping entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<ShippingDetailsDto?> Handle(
        GetByIdShipping command,
        [FromServices] IShippingService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Shipping with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<ShippingDetailsDto>(entity);

        logger.LogDebug($"Retrieving Shipping: {entityDto}");

        return entityDto;
    }
}
