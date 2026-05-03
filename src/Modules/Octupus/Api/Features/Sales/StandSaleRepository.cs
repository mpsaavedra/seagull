using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Sales;

public interface IStandSaleRepository: IRepository<StandSale>
{
    
}

public class StandSaleRepository : Repository<StandSale, ApplicationDbContext>, IStandSaleRepository, IScopedLifescope
{
    public StandSaleRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
