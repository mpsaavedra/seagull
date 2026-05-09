using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Moneys;

public interface IMoneyService : IService<Money>
{

}

public class MoneyService(ApplicationDbContext dbContext, IMapper mapper, ILogger<MoneyService> logger) :

    Service<Money, ApplicationDbContext>(dbContext, mapper, logger), IMoneyService, IScopedLifescope
{
}
