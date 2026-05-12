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
        logger.LogInformation($"Fetching SupplierPhonees, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);
        return (
            mapper.Map<List<SupplierPhoneDto>>(response.Value.Data),
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

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, false, cancellationToken);
        if (entity is null)
            return null;
        var entityDto = mapper.Map<SupplierPhoneDetailsDto>(entity);
        return entityDto;
    }
}
