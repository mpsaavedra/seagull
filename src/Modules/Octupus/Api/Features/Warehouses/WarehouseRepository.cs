using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Warehouses;

public interface IWarehouseRepository: IRepository<Warehouse>
{
    
}

public class WarehouseRepository : Repository<Warehouse, ApplicationDbContext>, IWarehouseRepository, IScopedLifescope
{
    public WarehouseRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
