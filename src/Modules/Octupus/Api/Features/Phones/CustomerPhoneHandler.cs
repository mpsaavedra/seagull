using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Phones;

public class CustomerPhoneHandler(ILogger<CustomerPhoneHandler> logger)
{
    public async Task<(List<CustomerPhoneDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetCustomerPhone command,
        [FromServices] ICustomerPhoneService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching CustomerPhone, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<CustomerPhoneDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} CustomerPhone entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<CustomerPhoneDetailsDto?> Handle(
        GetByIdCustomerPhone command,
        [FromServices] ICustomerPhoneService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching CustomerPhone with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<CustomerPhoneDetailsDto>(entity);

        logger.LogDebug($"Retrieving CustomerPhone: {entityDto}");

        return entityDto;
    }
}
