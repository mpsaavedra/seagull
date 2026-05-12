using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Octupus.Api.Features.Sales;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Payments;

public class StandSalePaymentHandler(ILogger<StandSalePaymentHandler> logger)
{
    public async Task<(List<StandSalePaymentDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetStandSalePayment command,
        [FromServices] IStandSalePaymentService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching StandSalePaymentes, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);
        return (
            mapper.Map<List<StandSalePaymentDto>>(response.Value.Data),
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<StandSalePaymentDetailsDto?> Handle(
        GetByIdStandSalePayment command,
        [FromServices] IStandSalePaymentService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching StandSalePayment with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, false, cancellationToken);
        if (entity is null)
            return null;
        var entityDto = mapper.Map<StandSalePaymentDetailsDto>(entity);
        return entityDto;
    }
}
