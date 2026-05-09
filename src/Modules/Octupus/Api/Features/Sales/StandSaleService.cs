using System;
using AutoMapper;
using Octupus.Api.Data;
using Octupus.Api.Features.Stands;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Sales;

public interface IStandSaleService : IService<StandSale>
{

}
public class StandSaleService(ApplicationDbContext dbContext, IMapper mapper, ILogger<StandSaleService> logger) :
    Service<StandSale, ApplicationDbContext>(dbContext, mapper, logger), IStandSaleService, IScopedLifescope
{
}
