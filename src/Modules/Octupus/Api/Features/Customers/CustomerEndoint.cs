using System;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Customers;

public class CustomerEndoint : IEndpointInstaller
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet("/api/customer", (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("ListCustomers", ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new GetCustomer()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .Bind<GetCustomer?, PaginatedResponse<Customer>>(async qry =>
                {
                    var response = await bus.InvokeAsync<(List<Customer> Data, bool HasPreviousPage, bool HasNextPage)>(qry, ct);
                    return Result.Success(PaginatedResponse<Customer>.CreatePaginated(
                        response.Data,
                        response.HasPreviousPage,
                        response.HasNextPage
                    ));
                })
                .Match(
                    onSuccess: value => Result.Success(value),
                    onFailure: error => Result.Failure(error)
                ));
    }
}
