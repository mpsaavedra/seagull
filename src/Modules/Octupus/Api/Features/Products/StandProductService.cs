using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Products;

public interface IStandProductService : IService<StandProduct>
{

}

public class StandProductService(ApplicationDbContext dbContext, IMapper mapper, ILogger<StandProductService> logger) :
    Service<StandProduct, ApplicationDbContext>(dbContext, mapper, logger), IStandProductService, IScopedLifescope
{
}
