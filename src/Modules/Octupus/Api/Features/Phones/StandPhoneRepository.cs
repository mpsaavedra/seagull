using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Phones;

public interface IStandPhoneRepository : IRepository<StandPhone>
{
    
}

public class StandPhoneRepository : Repository<StandPhone, ApplicationDbContext>, IStandPhoneRepository, IScopedLifescope
{
    public StandPhoneRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
