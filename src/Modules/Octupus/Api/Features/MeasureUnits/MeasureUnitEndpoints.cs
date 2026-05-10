using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.MeasureUnits;

public class MeasureUnitEndpoints : IEndpointInstaller
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet("/api/measureunit", (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("ListMeasureUnits", ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new GetMeasureUnit()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .Bind(async qry =>
                {
                    var response = await bus.InvokeAsync<(List<MeasureUnit> Data, bool HasPreviousPage, bool HasNextPage)>(qry!, ct);
                    return Result.Success(PaginatedResponse<MeasureUnit>.CreatePaginated(
                        response.Data, response.HasPreviousPage, response.HasNextPage
                    ));
                }));
    }
}
