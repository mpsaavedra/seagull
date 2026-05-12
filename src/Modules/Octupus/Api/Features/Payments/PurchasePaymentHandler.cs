using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Payments;

public class PurchasePaymentHandler(ILogger<PurchasePaymentHandler> logger)
{
    public async Task<(List<PurchasePaymentDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetPurchasePayment command,
        [FromServices] IPurchasePaymentService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching PurchasePaymentes, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);
        return (
            mapper.Map<List<PurchasePaymentDto>>(response.Value.Data),
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<PurchasePaymentDetailsDto?> Handle(
        GetBydIdPurchasePayment command,
        [FromServices] IPurchasePaymentService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching PurchasePayment with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, false, cancellationToken);
        if (entity is null)
            return null;
        var entityDto = mapper.Map<PurchasePaymentDetailsDto>(entity);
        return entityDto;
    }
}
