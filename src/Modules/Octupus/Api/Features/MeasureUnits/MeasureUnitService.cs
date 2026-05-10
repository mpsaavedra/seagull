using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.MeasureUnits;

public interface IMeasureUnitService : IService<MeasureUnit>
{

}

public class MeasureUnitService(ApplicationDbContext dbContext, IMapper mapper, ILogger<MeasureUnitService> logger) :
    Service<MeasureUnit, ApplicationDbContext>(dbContext, mapper, logger), IMeasureUnitService, IScopedLifescope
{
}
