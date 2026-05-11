using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Products;

public interface ISaleProductService : IService<SaleProduct>
{

}

public class SaleProductService(ApplicationDbContext dbContext, IMapper mapper, ILogger<SaleProductService> logger) :
    Service<SaleProduct, ApplicationDbContext>(dbContext, mapper, logger), ISaleProductService, IScopedLifescope
{
}
