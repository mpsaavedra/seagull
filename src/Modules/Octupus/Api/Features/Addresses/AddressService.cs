using System;
using System.Formats.Tar;
using Octupus.Api.Data;
using Seagull;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;
using Spectre.Console.Rendering;

namespace Octupus.Api.Features.Addresses;

public interface IAddressService: IService<Address>
{
}

public class AddressService : Service<Address, ApplicationDbContext>, IAddressService, ITransientLifescope
{
    public AddressService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
