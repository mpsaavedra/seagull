using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Addresses;

public interface IAddressRepository : IRepository<Address>
{
}

public sealed class AddressRepository : Repository<Address, ApplicationDbContext>, IAddressRepository, IScopedLifescope
{
    public AddressRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
