using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Products;

public interface IStandSaleProductService : IService<StandSaleProduct>
{

}
public class StandSaleProductService(ApplicationDbContext dbContext, IMapper mapper, ILogger<StandSaleProductService> logger) :
    Service<StandSaleProduct, ApplicationDbContext>(dbContext, mapper, logger), IStandSaleProductService, IScopedLifescope
{
}
