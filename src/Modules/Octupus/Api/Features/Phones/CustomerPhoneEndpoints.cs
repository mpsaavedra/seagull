using System;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Phones;

public class CustomerPhoneEndpoints : IEndpointInstaller
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet("/api/customerphone", (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("ListCustomerPhones", ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new GetCustomerPhone()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .Bind(async qry =>
                {
                    var response = await bus.InvokeAsync<(List<CustomerPhone> Data, bool HasPreviousPage, bool HasNextPage)>(qry!, ct);
                    return Result.Success(PaginatedResponse<CustomerPhone>.CreatePaginated(
                        response.Data, response.HasPreviousPage, response.HasNextPage
                    ));
                }));
    }
}
