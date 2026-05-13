using System;
using System.ComponentModel;
using System.Reflection.Metadata;
using AutoMapper;
using ImTools;
using Marten;
using Marten.Linq.SoftDeletes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Octupus.Api.Data;
using Octupus.Contracts.Dtos;
using Octupus.Contracts.Events;
using Seagull.Data;
using Seagull.Messaging;

namespace Octupus.Api.Features.Addresses;

public class AddressHandler(ILogger<AddressHandler> logger)
{
    public async Task<(List<AddressDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetAddress command,
        [FromServices] IAddressService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Address, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<AddressDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} Address entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<AddressDetailsDto?> Handle(
        GetByIdAddress command,
        [FromServices] IAddressService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Address with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<AddressDetailsDto>(entity);

        logger.LogDebug($"Retrieving Address: {entityDto}");

        return entityDto;
    }

    public async Task<string?> Handle(
        CreateAddress command,
        [FromServices] IAddressService service,
        [FromServices] IMapper mapper,
        [FromServices] IMessageBus bus,
        CancellationToken ct = default
    )
    {
        throw new NotImplementedException();
    }

    public async Task<(AddressDto Data, bool Success)> Handle(
        UpdateAddress command,
        [FromServices] IAddressService service,
        [FromServices] IMapper mapper,
        [FromServices] IMessageBus bus,
        CancellationToken ct = default
    )
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Handle(
        DeleteAddress command,
        [FromServices] IAddressService service,
        [FromServices] IMessageBus bus,
        CancellationToken ct = default
    )
    {
        throw new NotImplementedException();
    }
}