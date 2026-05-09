using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Cities;

public interface ICityService : IService<City>
{
}

public class CityService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) :
    Service<City, ApplicationDbContext>(dbContext, mapper, logger), ICityService, IScopedLifescope
{
}
