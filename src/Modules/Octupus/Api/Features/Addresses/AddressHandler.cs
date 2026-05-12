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
using Seagull.Data;
using Seagull.Messaging;

namespace Octupus.Api.Features.Addresses;

public class AddressHandler(ILogger<AddressHandler> logger, IMapper mapper)
{
    public async Task<(List<AddressDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetAddress command,
        [FromServices] IAddressService service,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching addresses, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);
        return (
            mapper.Map<List<AddressDto>>(response.Value.Data),
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
        logger.LogInformation($"Fetching address with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, false, cancellationToken);
        if (entity is null)
            return null;
        var entityDto = mapper.Map<AddressDetailsDto>(entity);
        return entityDto;
    }
}