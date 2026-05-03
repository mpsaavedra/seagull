using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Moneys;

public interface ICurrencyRepository : IRepository<Currency>
{
    
}

public class CurrencyRepository : Repository<Currency, ApplicationDbContext>, ICurrencyRepository, IScopedLifescope
{
    public CurrencyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
