using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Stands;

public interface IStandRepository: IRepository<Stand>
{
    
}

public class StandRepository : Repository<Stand, ApplicationDbContext>, IStandRepository, IScopedLifescope
{
    public StandRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
