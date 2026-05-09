using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Moneys;

public interface ICurrencyService : IService<Currency>
{
}

public class CurrencyService(ApplicationDbContext dbContext, IMapper mapper, ILogger<CurrencyService> logger) :
    Service<Currency, ApplicationDbContext>(dbContext, mapper, logger), ICurrencyService, IScopedLifescope
{
}
