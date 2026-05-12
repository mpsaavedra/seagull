using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Api.Features.Categories;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Moneys;

public class MoneyHandler(ILogger<MoneyHandler> logger)
{
    public async Task<(List<MoneyDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetMoney command,
        [FromServices] IMoneyService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Money, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<MoneyDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} Money entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<MoneyDetailsDto?> Handle(
        GetByIdMoney command,
        [FromServices] IMoneyService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Money with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<MoneyDetailsDto>(entity);

        logger.LogDebug($"Retrieving Money: {entityDto}");

        return entityDto;
    }
}
