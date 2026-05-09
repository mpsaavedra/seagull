using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Stands;

public interface IStandService : IService<Stand>
{
}

public class StandService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) :
    Service<Stand, ApplicationDbContext>(dbContext, mapper, logger), IStandService, IScopedLifescope
{
}
