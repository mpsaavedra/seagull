using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Payments;

public class SalePaymentHandler(ILogger<SalePaymentHandler> logger)
{
    public async Task<(List<SalePaymentDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetSalePayment command,
        [FromServices] ISalePaymentService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching SalePaymentes, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);
        return (
            mapper.Map<List<SalePaymentDto>>(response.Value.Data),
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<SalePaymentDetailsDto?> Handle(
        GetByIdSalePayment command,
        [FromServices] ISalePaymentService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching SalePayment with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, false, cancellationToken);
        if (entity is null)
            return null;
        var entityDto = mapper.Map<SalePaymentDetailsDto>(entity);
        return entityDto;
    }
}
