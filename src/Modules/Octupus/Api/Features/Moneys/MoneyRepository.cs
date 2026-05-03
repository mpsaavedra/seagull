using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Moneys;

public interface IMoneyRepository : IRepository<Money>
{
    
}

public class MoneyRepository : Repository<Money, ApplicationDbContext>, IMoneyRepository, IScopedLifescope
{
    public MoneyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
