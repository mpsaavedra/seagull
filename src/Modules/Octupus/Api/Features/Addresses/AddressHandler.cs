using System;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Comands;
using Octupus.Contracts.Queries;
using Octupus.Contracts.Responses;
using Seagull.Data;
using Seagull.Messaging;

namespace Octupus.Api.Features.Addresses;

public class AddressHandler
{
    public async Task<CreateAddressResponse> Handle(
        CreateAddressCommand command, 
        [FromServices] IUnitOfWork uow, 
        [FromServices] IMessageBus bus, 
        CancellationToken cancellationToken = default)
    {
        var repo = uow.Repository<Address>();
        return new CreateAddressResponse(addressId: "this-is-the-id-from-the-handler");
    }

    public async Task Handle(
        UpdateAddressCommand command,
        [FromServices] IUnitOfWork uow, 
        CancellationToken cancellationToken = default)
    {
    }

    public async Task Handle(
        DeleteAddressCommand command,
        [FromServices] IUnitOfWork uow,
        [FromServices] IMessageBus bus,
        CancellationToken cancellationToken = default)
    {
    }

    public async Task Handle(
        ListAllAddress query,
        [FromServices] IUnitOfWork uow,
        [FromServices] IMessageBus bus,
        CancellationToken cancellationToken = default)
    {
        
    }

    public async Task Handle(
        GetByIdAddress query,
        [FromServices] IUnitOfWork uow,
        [FromServices] IMessageBus bus,
        CancellationToken cancellationToken = default)
    {
    }
}
