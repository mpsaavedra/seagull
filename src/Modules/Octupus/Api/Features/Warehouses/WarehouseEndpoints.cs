using System;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Warehouses;

public class WarehouseEndpoints : IEndpointInstaller
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet("/api/warehouse", (IMessageBus bus, int pageInex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("ListWarehouses", ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new GetWarehouse()
                {
                    PageIndex = pageInex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .Bind(async qry =>
                {
                    var response = await bus.InvokeAsync<(List<Warehouse> Data, bool HasPreviousPage, bool HasNextPage)>(qry!, ct);
                    return Result.Success(PaginatedResponse<Warehouse>.CreatePaginated(
                        response.Data, response.HasPreviousPage, response.HasNextPage
                    ));
                })
                .Match(
                    onSuccess: value => Result.Success(value),
                    onFailure: error => Result.Failure(error)
                ));
    }
}
