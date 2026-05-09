using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Dtos;
using Octupus.Contracts.Events;
using Octupus.Contracts.Queries;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Extensions;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Addresses;

public class AddressEndpoints : IEndpointInstaller
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapPost("/api/address", (AddressDto request, IMessageBus bus, CancellationToken ct = default) =>
            Result
                .Create(request, ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new CreateAddress()
                {
                    Street = request.Street,
                    InnerAddress = request.InnerAddress,
                    CityId = request.CityId
                })
                .Ensure(x => x is not null, ErrorCodes.ApiErrors.RequestDataCouldNotBeNull)!
                .Bind<CreateAddress, string?>(async cmd =>
                {
                    var response = await bus.InvokeAsync<string?>(cmd, ct);
                    return response is null ?
                        Result.Failure<string?>(ErrorCodes.OctupusApi.AddressCouldNotBeCreated) :
                        response;
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));

        app.MapPut("/api/address", (AddressDto request, IMessageBus bus, CancellationToken ct = default) =>
            Result
                .Create(request, ErrorCodes.ApiErrors.UnProcessableRequest)
                .Ensure(x => !request.Id.IsNullEmptyOrWhiteSpace(), ErrorCodes.OctupusApi.AddressIdCouldNotBeNull)
                .Map(_ => new UpdateAddress()
                {
                    Id = request.Id!,
                    Street = request.Street,
                    CityId = request.CityId
                })
                .Bind<UpdateAddress?, string?>(async cmd =>
                {
                    if (cmd is null) return null!;
                    var response = await bus.InvokeAsync<string?>(cmd!, ct);
                    return response is null ?
                        Result.Failure<string?>(ErrorCodes.OctupusApi.AddressCouldNotBeCreated) :
                        response;
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));

        app.MapDelete("/api/address", (string id, IMessageBus bus, CancellationToken ct = default) =>
            Result
                .Create(id, ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new DeleteAddress()
                {
                    Id = id,
                    SoftDelete = true
                })
                .Bind<DeleteAddress?, bool>(async cmd =>
                {
                    if (cmd is null) return false;
                    var response = await bus.InvokeAsync<bool>(cmd!, ct);
                    return !response ?
                        Result.Failure<bool>(ErrorCodes.OctupusApi.AddressCouldNotBeCreated) :
                        response;
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));

        app.MapGet("/api/address", (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("ListAddress", ErrorCodes.ApiErrors.UnProcessableRequest)!
                .Map(_ => new GetAddress()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .Bind<GetAddress?, PaginatedResponse<Address>>(async cmd =>
                {
                    if (cmd is null)
                    {
                        return Result.Failure<PaginatedResponse<Address>>(
                            ErrorCodes.ApiErrors.RequestDataCouldNotBeNull
                        )!;
                    }
                    var response = await bus.InvokeAsync<(IQueryable<Address> Data, bool HasPreviousPage, bool HasNextPage)>(cmd!, ct);
                    return Result.Success(PaginatedResponse<Address>.CreatePaginated(
                        response.Data,
                        response.HasPreviousPage,
                        response.HasNextPage
                    ));
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));

        app.MapGet("/api/address/{id}", (string id, IMessageBus bus, CancellationToken ct = default) =>
            Result
                .Create("GetByIdAddress", ErrorCodes.ApiErrors.UnProcessableRequest)!
                .Map(_ => new GetByIdAddress(id))
                .Bind<GetByIdAddress?, AddressDto?>(async cmd =>
                {
                    if (cmd is null)
                    {
                        return Result.Failure<AddressDto>(
                            ErrorCodes.ApiErrors.RequestDataCouldNotBeNull
                        );
                    }
                    var response = await bus.InvokeAsync<AddressDto>(cmd!, ct);
                    return response;
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));
    }
}