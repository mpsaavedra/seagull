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
    public async Task<CreateAddressResponse> Handle(
        CreateAddressCommand command, 
        [FromServices] IAddressService service, 
        [FromServices] IMessageBus bus, 
        CancellationToken cancellationToken = default)
    {
        // var entry = service.AddAsync();
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

    public async Task<GetAddressResponse> Handle(
        GetAddressQuery query,
        [FromServices] IAddressService service,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Retrieving addresses");
        var result = await service.GetAllAsync(pageIndex: query.PageIndex, pageSize: query.PageSize,
            includeSoftDeleted: query.SoftDeleted, cancellationToken: cancellationToken);
        
        if(result.HasNoValue)
        {
            return new GetAddressResponse(new List<AddressDto>().AsQueryable(), false, false);    
        }
        
        var response = 
            from value in result.Value.data
            select new AddressDto();
            
        return new GetAddressResponse(response, result.Value.hasPreviousPage, result.Value.hasNextPage);    
    }

    public async Task Handle(
        GetByIdAddressQuery query,
        [FromServices] IUnitOfWork uow,
        [FromServices] IMessageBus bus,
        CancellationToken cancellationToken = default)
    {
    }
}
