using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Sales;

public interface ISaleRepository: IRepository<Sale>
{
    
}

public class SaleRepository : Repository<Sale, ApplicationDbContext>, ISaleRepository, IScopedLifescope
{
    public SaleRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
