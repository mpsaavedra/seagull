using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Customers;

public class CustomerHandler(ILogger<Customer> logger)
{
    public async Task<(List<CustomerDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetCustomer command,
        [FromServices] ICustomerService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Customer, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<CustomerDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} Customer entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<CustomerDetailsDto?> Handle(
        GetByIdCustomer command,
        [FromServices] ICustomerService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Customer with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<CustomerDetailsDto>(entity);

        logger.LogDebug($"Retrieving Customer: {entityDto}");

        return entityDto;
    }
}
