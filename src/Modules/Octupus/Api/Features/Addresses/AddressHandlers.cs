using System;
using System.ComponentModel;
using System.Reflection.Metadata;
using AutoMapper;
using Marten;
using Marten.Linq.SoftDeletes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Octupus.Api.Data;
using Octupus.Contracts.Dtos;
using Octupus.Contracts.Events;
using Octupus.Contracts.Queries;
using Seagull.Data;
using Seagull.Messaging;

namespace Octupus.Api.Features.Addresses;

public class AddressHandler(ILogger<AddressHandler> logger)
{
    public async Task<string?> Handle(
        CreateAddress command,
        [FromServices] IAddressService service,
        [FromServices] IMapper mapper,
        [FromServices] IMessageBus bus,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Creating new address");

        var request = mapper.Map<Address>(command);
        var result = await service.AddAsync(request, cancellationToken);

        if (result.HasNoValue)
        {
            return null;
        }

        var @event = new CreatedAddress(result.Value);
        await bus.PublishAsync(@event, cancellationToken);

        return result.Value;
    }

    public async Task<string?> Handle(
        UpdateAddress command,
        [FromServices] IAddressService service,
        [FromServices] IMapper mapper,
        [FromServices] IMessageBus bus,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Updating address {command.Id}");

        var entity = mapper.Map<Address>(command);
        var entityDto = mapper.Map<AddressDto>(entity);
        var result = await service.UpdateAsync(entity, cancellationToken);

        if (result.HasNoValue)
        {
            return null;
        }

        var @event = new UpdatedAddress(entityDto);
        await bus.PublishAsync(@event, cancellationToken);

        return entity.Id;
    }

    public async Task<bool> Handle(
        DeleteAddress command,
        [FromServices] IAddressService service,
        [FromServices] IMapper mapper,
        [FromServices] IMessageBus bus,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Deleting address {command.Id}");

        var entity = mapper.Map<Address>(command);
        var result = await service.DeleteAsync(entity, command.SoftDelete, cancellationToken);

        if (result.HasNoValue)
        {
            return false;
        }

        var @event = new DeletedAddress(entity.Id);
        await bus.PublishAsync(@event, cancellationToken);

        return result.Value;
    }

    public async Task<(IQueryable<Address> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetAddress command,
        [FromServices] IAddressService service,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching addresses, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var entities = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);
        return entities.Value;
    }

    public async Task<AddressDto?> Handle(
        GetByIdAddress command,
        [FromServices] IAddressService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching address with Id: '{command.AddressId}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.AddressId, false, cancellationToken);
        if (entity is null)
            return null;
        var entityDto = mapper.Map<AddressDto>(entity);
        return entityDto;
    }
}