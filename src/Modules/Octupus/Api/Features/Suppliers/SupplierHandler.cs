using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Suppliers;

public class SupplierHandler(ILogger<SupplierHandler> logger)
{
    public async Task<(List<SupplierDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetSupplier command,
        [FromServices] ISupplierService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Supplier, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<SupplierDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} Supplier entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<SupplierDetailsDto?> Handle(
        GetByIdSupplier command,
        [FromServices] ISupplierService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Supplier with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<SupplierDetailsDto>(entity);

        logger.LogDebug($"Retrieving Supplier: {entityDto}");

        return entityDto;
    }
}
