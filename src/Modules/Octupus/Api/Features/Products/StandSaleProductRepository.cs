using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Products;

public interface IStandSaleProductRepository: IRepository<StandSaleProduct>
{
    
}

public class StandSaleProductRepository : Repository<StandSaleProduct, ApplicationDbContext>, IStandSaleProductRepository, IScopedLifescope
{
    public StandSaleProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
