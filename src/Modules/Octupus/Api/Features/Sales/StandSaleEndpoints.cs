using System;
using AutoMapper;
using Octupus.Contracts.Dtos;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Sales;

public class StandSaleEndpoints : IEndpointInstaller
{
    public static string ApiEndpoint = "/api/stand-sales/";
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet(ApiEndpoint, (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("List", ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new GetStandSale()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .TryCatch(async qry =>
                {
                    var response = await bus.InvokeAsync<(List<StandSaleDto> Data, bool HasPreviousPage, bool HasNextPage)>(qry!, ct);
                    return Result.Success(PaginatedResponse<StandSaleDto>.CreatePaginated(
                        response.Data,
                        response.HasPreviousPage,
                        response.HasNextPage
                    ));
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));

        app.MapGet(ApiEndpoint + "{id}", (IMessageBus bus, string id, CancellationToken ct = default) =>
            Result
                .Create("GetBydId")
                .Map(_ => new GetByIdStandSale(id))
                .TryCatch(async qry =>
                {
                    var response = await bus.InvokeAsync<StandSaleDetailsDto>(qry!, ct);
                    return Result.Success(response);
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));
    }
}
