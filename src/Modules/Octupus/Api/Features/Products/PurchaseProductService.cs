using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Products;

public interface IPurchaseProductService : IService<PurchaseProduct>
{

}

public class PurchaseProductService(ApplicationDbContext dbContext, IMapper mapper, ILogger<PurchaseProductService> logger) :
    Service<PurchaseProduct, ApplicationDbContext>(dbContext, mapper, logger), IPurchaseProductService, IScopedLifescope
{
}
