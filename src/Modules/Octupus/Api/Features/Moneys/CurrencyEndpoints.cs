using System;
using AutoMapper;
using Octupus.Contracts.Dtos;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Moneys;

public class CurrencyEndpoints : IEndpointInstaller
{
    public static string ApiEndpoint = "/api/currencies/";
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet(ApiEndpoint, (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("ListCurrency", ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new GetCurrency()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .TryCatch(async qry =>
                {
                    var response = await bus.InvokeAsync<(List<CurrencyDto> Data, bool HasPreviousPage, bool HasNextPage)>(qry!, ct);
                    return Result.Success(PaginatedResponse<CurrencyDto>.CreatePaginated(
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
                .Create("GetBydIdCustomer")
                .Map(_ => new GetByIdCurrency(id))
                .TryCatch(async qry =>
                {
                    var response = await bus.InvokeAsync<CurrencyDetailsDto>(qry!, ct);
                    return Result.Success(response);
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));
    }
}
