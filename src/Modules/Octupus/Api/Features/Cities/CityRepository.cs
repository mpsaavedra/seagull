using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Cities;

public interface ICityRepository : IRepository<City>
{
    
}

public class CityRepository : Repository<City, ApplicationDbContext>, ICityRepository, IScopedLifescope
{
    public CityRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
