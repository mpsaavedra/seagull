using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Products;

public interface IStandProductRepository: IRepository<StandProduct>
{
    
}

public class StandProductRepository : Repository<StandProduct, ApplicationDbContext>, IStandProductRepository, IScopedLifescope
{
    public StandProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
