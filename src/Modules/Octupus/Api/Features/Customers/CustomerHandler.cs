using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Customers;

public class CustomerHandler(ILogger<Customer> logger)
{
    public async Task<(List<Customer> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
           GetCustomer command,
           [FromServices] ICustomerService service,
           CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Customer, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var entities = await service.GetAllAsync(
            pageIndex: command.PageIndex,
            pageSize: command.PageSize,
            includeSoftDeleted: false,
            cancellationToken: cancellationToken);

        return entities.Value;
    }
}
