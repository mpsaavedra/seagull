using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Products;

public interface ISaleProductRepository: IRepository<SaleProduct>
{
    
}

public class SaleProductRepository : Repository<SaleProduct, ApplicationDbContext>, ISaleProductRepository, IScopedLifescope
{
    public SaleProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
