using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Invoices;

public class InvoiceHandler(ILogger<InvoiceHandler> logger)
{
    public async Task<(List<InvoiceDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetInvoice command,
        [FromServices] IInvoiceService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Invoice, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<InvoiceDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} Invoice entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<InvoiceDetailsDto?> Handle(
        GetByIdInvoice command,
        [FromServices] IInvoiceService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Invoice with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<InvoiceDetailsDto>(entity);

        logger.LogDebug($"Retrieving Invoice: {entityDto}");

        return entityDto;
    }
}
