using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Invoices;

public class PurchaseInvoiceHandler(ILogger<PurchaseInvoiceHandler> logger)
{
    public async Task<(List<PurchaseInvoiceDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetPurchaseInvoice command,
        [FromServices] IPurchaseInvoiceService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching PurchaseInvoice, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<PurchaseInvoiceDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} PurchaseInvoice entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<PurchaseInvoiceDetailsDto?> Handle(
        GetByIdPurchaseInvoice command,
        [FromServices] IPurchaseInvoiceService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching PurchaseInvoice with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<PurchaseInvoiceDetailsDto>(entity);

        logger.LogDebug($"Retrieving PurchaseInvoice: {entityDto}");

        return entityDto;
    }
}
