using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Phones;

public interface IWareHousePhoneRepository: IRepository<WarehousePhone>
{
}

public class WareHousePhoneRepository : Repository<WarehousePhone, ApplicationDbContext>, IWareHousePhoneRepository, IScopedLifescope
{
    public WareHousePhoneRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
