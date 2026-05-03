using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Purchases;

public interface IPurchaseRepository: IRepository<Purchase>
{
    
}

public class PurchaseRepository : Repository<Purchase, ApplicationDbContext>, IPurchaseRepository, IScopedLifescope
{
    public PurchaseRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
