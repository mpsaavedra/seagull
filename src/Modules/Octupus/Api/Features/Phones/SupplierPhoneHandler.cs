using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Phones;

public class SupplierPhoneHandler(ILogger<SupplierPhoneHandler> logger)
{
    public async Task<(List<SupplierPhoneDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetSupplierPhone command,
        [FromServices] ISupplierPhoneService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching SupplierPhone, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<SupplierPhoneDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} SupplierPhone entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<SupplierPhoneDetailsDto?> Handle(
        GetByIdSupplierPhone command,
        [FromServices] ISupplierPhoneService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching SupplierPhone with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<SupplierPhoneDetailsDto>(entity);

        logger.LogDebug($"Retrieving SupplierPhone: {entityDto}");

        return entityDto;
    }
}
