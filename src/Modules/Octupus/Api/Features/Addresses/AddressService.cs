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
}

public class AddressService(ApplicationDbContext dbCOntext, ILogger<AddressService> logger, AutoMapper.IMapper mapper) :
    Service<Address, ApplicationDbContext>(dbCOntext, mapper, logger), IAddressService, IScopedLifescope
{
    private readonly ILogger<AddressService> _logger = logger;
}
