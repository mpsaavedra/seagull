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
        logger.LogInformation($"Fetching StandSalees, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);
        return (
            mapper.Map<List<StandSaleDto>>(response.Value.Data),
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

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, false, cancellationToken);
        if (entity is null)
            return null;
        var entityDto = mapper.Map<StandSaleDetailsDto>(entity);
        return entityDto;
    }
}
