using System;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Shippings;

public class ShippingEndpoints : IEndpointInstaller
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet("/api/shipping", (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("ListShippings", ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new GetShiping()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .Bind(async qry =>
                {
                    var response = await bus.InvokeAsync<(List<Shipping> Data, bool HasPreviousPage, bool HasNextPage)>(qry!, ct);
                    return Result.Success(PaginatedResponse<Shipping>.CreatePaginated(
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
