using System;
using System.ComponentModel;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using Octupus.Contracts.Comands;
using Octupus.Contracts.Dtos;
using Octupus.Contracts.Queries;
using Octupus.Contracts.Responses;
using Seagull.Data;
using Seagull.Messaging;

namespace Octupus.Api.Features.Addresses;

public class AddressHandler(ILogger<AddressHandler> logger)
{
    public async Task<CreatedAddressResponse> Handle(
        CreateAddress command,
        [FromServices] IAddressService service,
        [FromServices] IMessageBus bus,
        CancellationToken cancellationToken = default)
    {
        // var entry = service.AddAsync();
        return new CreatedAddressResponse(addressId: "this-is-the-id-from-the-handler");
    }

    public async Task Handle(
        UpdateAddress command,
        [FromServices] IUnitOfWork uow,
        CancellationToken cancellationToken = default)
    {
    }

    public async Task Handle(
        DeleteAddress command,
        [FromServices] IUnitOfWork uow,
        [FromServices] IMessageBus bus,
        CancellationToken cancellationToken = default)
    {
    }

    public async Task<GetAddressesResponse> Handle(
        GetAddressQuery query,
        [FromServices] IAddressService service,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Retrieving addresses");
        var result = await service.GetAllAsync(pageIndex: query.PageIndex, pageSize: query.PageSize, cancellationToken: cancellationToken);

        if (result.HasNoValue)
        {
            return new GetAddressesResponse(new List<AddressDto>().AsQueryable(), false, false);
        }

        logger.LogDebug($"It has been retrieved '{result.Value.data.Count()}' items");

        var response =
            from value in result.Value.data
            select new AddressDto();

        return new GetAddressesResponse(response, result.Value.hasPreviousPage, result.Value.hasNextPage);
    }

    public async Task Handle(
        GetByIdAddressQuery query,
        [FromServices] IUnitOfWork uow,
        [FromServices] IMessageBus bus,
        CancellationToken cancellationToken = default)
    {
    }
}
