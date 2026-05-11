using System;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Products;

public class StandSaleProductEndpoints : IEndpointInstaller
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet("/api/stansaleproduct", (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("ListStandSaleProducts", ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new GetStandSaleProduct()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .Bind(async qry =>
                {
                    var response = await bus.InvokeAsync<(List<StandSaleProduct> Data, bool HasPreviousPage, bool HasNextPage)>(qry!, ct);
                    return Result.Success(PaginatedResponse<StandSaleProduct>.CreatePaginated(
                        response.Data, response.HasPreviousPage, response.HasNextPage
                    ));
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));
    }
}
