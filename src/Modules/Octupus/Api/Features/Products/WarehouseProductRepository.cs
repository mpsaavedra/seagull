using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Products;

public interface IWarehouseProductRepository: IRepository<WarehouseProduct>
{
    
}

public class WarehouseProductRepository : Repository<WarehouseProduct, ApplicationDbContext>, IWarehouseProductRepository, IScopedLifescope
{
    public WarehouseProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
