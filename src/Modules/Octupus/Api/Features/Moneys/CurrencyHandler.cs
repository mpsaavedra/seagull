using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Moneys;

public class CurrencyHandler(ILogger<CurrencyHandler> logger)
{
    public async Task<(List<CurrencyDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetCurrency command,
        [FromServices] ICurrencyService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Currency, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<CurrencyDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} Currency entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<CurrencyDetailsDto?> Handle(
        GetByIdCurrency command,
        [FromServices] ICurrencyService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Currency with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<CurrencyDetailsDto>(entity);

        logger.LogDebug($"Retrieving Currency: {entityDto}");

        return entityDto;
    }
}
