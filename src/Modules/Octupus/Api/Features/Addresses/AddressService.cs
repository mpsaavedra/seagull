using System;
using System.Formats.Tar;
using Octupus.Api.Data;
using Octupus.Contracts.Dtos;
using Octupus.Contracts.Queries;
using Octupus.Contracts.Requests;
using Octupus.Contracts.Responses;
using Seagull;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;
using Seagull.Plugins.ScripEngines.Lua;
using Spectre.Console.Rendering;

namespace Octupus.Api.Features.Addresses;

public interface IAddressService: IService<Address>
{
    Task<GetAddressesResponse> GetAddresses(GetAddressRequest request, CancellationToken cancellationToken = default);
    Task<AddressDto> GetAddressById(GetAddressById request, CancellationToken cancellationToken = default);
}

public class AddressService : Service<Address, ApplicationDbContext>, IAddressService, ITransientLifescope
{
    private readonly ILogger<AddressService> _logger;

    public AddressService(IUnitOfWork uow, ILogger<AddressService> logger): base(uow)
    {
        _logger = logger;
    }

    public Task<AddressDto> GetAddressById(GetAddressById request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }


    public async Task<GetAddressesResponse> GetAddresses(GetAddressRequest request, CancellationToken cancellationToken = default)
    {
        return new GetAddressesResponse(new List<AddressDto>().AsQueryable());
    }
}
