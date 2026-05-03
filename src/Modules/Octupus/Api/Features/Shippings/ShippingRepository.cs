using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Shippings;

public interface IShippingRepository: IRepository<Shipping>
{
    
}

public class ShippingRepository : Repository<Shipping, ApplicationDbContext>, IShippingRepository, IScopedLifescope
{
    public ShippingRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
