using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;
using Octupus.Contracts.Events;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Extensions;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Addresses;

public class AddressEndpoints : IEndpointInstaller
{
    public static string ApiEndpointRoot = "/api/addresses/";
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet(ApiEndpointRoot, (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("List", ErrorCodes.ApiErrors.UnProcessableRequest)!
                .Map(_ => new GetAddress()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .TryCatch(async qry =>
                {
                    var response = await bus.InvokeAsync<(List<AddressDto> Data, bool HasPreviousPage, bool HasNextPage)>(qry!, ct);
                    return Result.Success(PaginatedResponse<AddressDto>.CreatePaginated(
                        response.Data,
                        response.HasPreviousPage,
                        response.HasNextPage
                    ));
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));

        app.MapGet(ApiEndpointRoot + "{id}", (string id, IMessageBus bus, CancellationToken ct = default) =>
            Result
                .Create("GetById", ErrorCodes.ApiErrors.UnProcessableRequest)!
                .Map(_ => new GetByIdAddress(id))
                .TryCatch(async cmd =>
                {
                    var response = await bus.InvokeAsync<AddressDetailsDto>(cmd!, ct);
                    return Result.Success(response);
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));
    }
}