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
    public static string ApiEndpoint = "/api/addresses/";
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet(ApiEndpoint + "{id}", (IMessageBus bus, string id, CancellationToken ct = default) =>
            Result
                .Create("GetById")
                .Map(_ => new GetByIdAddress(id))
                .TryCatch(async qry =>
                {
                    var response = await bus.InvokeAsync<AddressDetailsDto>(qry!, ct);
                    return Result.Success(response);
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));

        app.MapGet(ApiEndpoint, (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("List")
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

        app.MapPost(ApiEndpoint, (IMessageBus bus, AddressDto input, CancellationToken ct = default) =>
            Result
                .Create("Create")
                .Map(_ => new CreateAddress
                {
                    Street = input.Street,
                    InnerAddress = input.InnerAddress,
                    CityId = input.CityId
                })
                .TryCatch(async cmd =>
                {
                    var response = await bus.InvokeAsync<string?>(cmd!, ct);
                    return !response.IsNullEmptyOrWhiteSpace() ?
                        Result.Success(response) :
                        Result.Failure<string?>(ErrorCodes.OctupusApi.AddressCouldNotBeCreated);
                }, ErrorCodes.OctupusApi.AddressCouldNotBeCreated)
                .Map(res =>
                {
                    if (res.IsFailure)
                        return Result.Failure<AddressDto>(res.Error)!;
                    return Result.Success(new AddressDto
                    {
                        Street = input.Street,
                        InnerAddress = input.InnerAddress,
                        CityId = input.CityId,
                        Id = res.Value
                    });
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));

        app.MapPut(ApiEndpoint, (IMessageBus bus, AddressDto input, CancellationToken ct = default) =>
            Result
                .Create("Update")
                .Ensure(_ => !input.Id.IsNullEmptyOrWhiteSpace(), ErrorCodes.OctupusApi.AddressIdIsRequired)
                .Map(_ => new UpdateAddress
                {
                    Id = input.Id!,
                    Street = input.Street,
                    InnerAddress = input.InnerAddress,
                    CityId = input.CityId
                })
                .TryCatch(async cmd =>
                {
                    var response = await bus.InvokeAsync<(AddressDto Data, bool Success)>(cmd!, ct);
                    return response.Success ?
                        Result.Success(response.Data) :
                        Result.Failure<AddressDto>(ErrorCodes.OctupusApi.AddressCouldNotBeUpdated)!;
                }, ErrorCodes.OctupusApi.AddressCouldNotBeUpdated)
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));

        app.MapDelete(ApiEndpoint + "{id}", (IMessageBus bus, string id, CancellationToken ct = default) =>
            Result
                .Create("Delete")
                .Map(_ => new DeleteAddress { Id = id })
                .TryCatch(async cmd =>
                {
                    var response = await bus.InvokeAsync<bool>(cmd!, ct);
                    return response ?
                        Result.Success(response) :
                        Result.Failure<bool>(ErrorCodes.OctupusApi.AddressCouldNotBeDeleted);

                }, ErrorCodes.OctupusApi.AddressCouldNotBeDeleted)
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));

        app.MapPost(ApiEndpoint + "{id}/customers/", () => Result.Create(""));
        app.MapDelete(ApiEndpoint + "{id}/customers/{customerId}", () => Result.Create(""));
        app.MapPost(ApiEndpoint + "{id}/stands/", () => Result.Create(""));
        app.MapDelete(ApiEndpoint + "{id}/stands/{customerId}", () => Result.Create(""));
        app.MapPost(ApiEndpoint + "{id}/suppliers/", () => Result.Create(""));
        app.MapDelete(ApiEndpoint + "{id}/suppliers/{customerId}", () => Result.Create(""));
        app.MapPost(ApiEndpoint + "{id}/warehouses/", () => Result.Create(""));
        app.MapDelete(ApiEndpoint + "{id}/warehouses/{customerId}", () => Result.Create(""));
    }
}