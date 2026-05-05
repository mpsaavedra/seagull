using Marten.Linq.MatchesSql;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Comands;
using Octupus.Contracts.Dtos;
using Octupus.Contracts.Queries;
using Octupus.Contracts.Requests;
using Octupus.Contracts.Responses;
using Seagull;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Addresses;

public class AddressEndpoints: IEndpointInstaller
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapPost("/api/address", (CreateAddressRequest request, IMessageBus bus, CancellationToken ct = default) =>
            Result
                .Create(request, ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new CreateAddressCommand(request.Street, request.InnerAddress, request.CityId))
                .Ensure(x => x is not null)! // place error
                .Bind<CreateAddressCommand, CreateAddressResponse>(async command =>
                {
                    var response = await bus.InvokeAsync<CreateAddressResponse>(command, ct);
                    return Result.Success(response);
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));

                // can keep processing the result here
                // .Map(response => {
                //     // Transform the response if needed
                //     return new { response.Id, Status = "Created" };
                // })
                // .Match(Results.Ok, Results.BadRequest);

        app.MapGet("/api/address", ([FromServices] IMessageBus bus, 
            int pageIndex = 1, int pageSize = 50,
            CancellationToken cancellationToken = default) =>
            Result
                .Create(new GetAddressQuery(
                    pageIndex, pageSize, false
                ))
                .Ensure(x => x is not null)!
                .Bind<GetAddressQuery, GetAddressResponse>(async query =>
                    await bus.InvokeAsync<GetAddressResponse>(query, cancellationToken))
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));

        app.MapGet("/api/address/{id}", ([FromServices] IMessageBus bus,
            [FromQuery] string id, CancellationToken cancellationToken = default) =>
            Result
                .Create(new GetByIdAddressQuery(id, false))
                .Ensure(x => x is not null)
                .Bind<GetByIdAddressQuery, AddressDto?>(async query =>
                    await bus.InvokeAsync<AddressDto?>(query, cancellationToken))
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));
    }
}