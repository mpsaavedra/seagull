using System;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Suppliers;

public class SupplierEndpoints : IEndpointInstaller
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet("/api/warehouse", (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("ListSupplier", ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new GetSupplier()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .Bind(async qry =>
                {
                    var response = await bus.InvokeAsync<(List<Supplier> Data, bool HasPreviousPage, bool HasNextPage)>(qry!, ct);
                    return Result.Success(PaginatedResponse<Supplier>.CreatePaginated(
                        response.Data, response.HasPreviousPage, response.HasNextPage
                    ));
                }));
    }
}
