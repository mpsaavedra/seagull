using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Products;

public interface IPurchaseProductRepository: IRepository<PurchaseProduct>
{
    
}

public class PurchaseProductRepository : Repository<PurchaseProduct, ApplicationDbContext>, IPurchaseProductRepository, IScopedLifescope
{
    public PurchaseProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
