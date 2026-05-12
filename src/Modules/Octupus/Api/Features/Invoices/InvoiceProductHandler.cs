using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Invoices;

public class InvoiceProductHandler(ILogger<InvoiceProductHandler> logger)
{
    public async Task<(List<InvoiceProductDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetInvoiceProduct command,
        [FromServices] IInvoiceProductService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching InvoiceProductes, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);
        return (
            mapper.Map<List<InvoiceProductDto>>(response.Value.Data),
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<InvoiceProductDetailsDto?> Handle(
        GetByIdInvoiceProduct command,
        [FromServices] IInvoiceProductService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching InvoiceProduct with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, false, cancellationToken);
        if (entity is null)
            return null;
        var entityDto = mapper.Map<InvoiceProductDetailsDto>(entity);
        return entityDto;
    }
}
