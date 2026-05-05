using Microsoft.AspNetCore.Http.HttpResults;
using Octupus.Contracts.Comands;
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
        app.MapPost("/api/address", (CreateAddressRequest cmd, IMessageBus bus, CancellationToken ct = default) =>
            Result
                .Create(cmd, ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(request => new CreateAddressCommand(request.Street, request.InnerAddress, request.CityId))
                .Ensure(x => {
                    return true; 
                })! // place error
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
    }
}