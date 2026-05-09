using System;
using System.Formats.Tar;
using Microsoft.EntityFrameworkCore;
using Octupus.Api.Data;
using Octupus.Contracts.Dtos;
using Seagull;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;
using Seagull.Plugins.ScripEngines.Lua;
using Spectre.Console.Rendering;

namespace Octupus.Api.Features.Addresses;

public interface IAddressService : IService<Address>
{
    // Task<GetAddressesResponse> GetAddresses(GetAddressRequest request, CancellationToken cancellationToken = default);
    // Task<AddressDto> GetAddressById(GetAddressById request, CancellationToken cancellationToken = default);
}

public class AddressService : Service<Address, ApplicationDbContext>, IAddressService, ITransientLifescope
{
    private readonly ILogger<AddressService> _logger;

    public AddressService(ApplicationDbContext dbCOntext, ILogger<AddressService> logger, AutoMapper.IMapper mapper) : base(dbCOntext, mapper, logger)
    {
        _logger = logger;
    }

    // public Task<AddressDto> GetAddressById(GetAddressById request, CancellationToken cancellationToken = default)
    // {
    //     throw new NotImplementedException();
    // }


    // public async Task<GetAddressesResponse> GetAddresses(GetAddressRequest request, CancellationToken cancellationToken = default)
    // {
    //     return new GetAddressesResponse(new List<AddressDto>().AsQueryable());
    // }
}
