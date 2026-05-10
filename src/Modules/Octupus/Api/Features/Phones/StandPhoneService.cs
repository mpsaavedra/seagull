using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Phones;

public interface IStandPhoneService : IService<StandPhone>
{

}
public class StandPhoneService(ApplicationDbContext dbContext, IMapper mapper, ILogger<StandPhoneService> logger) :
    Service<StandPhone, ApplicationDbContext>(dbContext, mapper, logger), IStandPhoneService, IScopedLifescope
{
}
