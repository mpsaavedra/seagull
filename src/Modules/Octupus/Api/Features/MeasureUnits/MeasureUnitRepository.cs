using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.MeasureUnits;

public interface IMeasureUnitRepository : IRepository<MeasureUnit>
{
    
}

public class MeasureUnitRepository : Repository<MeasureUnit, ApplicationDbContext>, IMeasureUnitRepository, IScopedLifescope
{
    public MeasureUnitRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
