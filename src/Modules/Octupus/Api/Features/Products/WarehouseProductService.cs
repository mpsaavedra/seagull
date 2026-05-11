using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Products;

public interface IWarehouseProductService : IService<WarehouseProduct>
{

}

public class WarehouseProductService(ApplicationDbContext dbContext, IMapper mapper, ILogger<WarehouseProductService> logger) :
    Service<WarehouseProduct, ApplicationDbContext>(dbContext, mapper, logger), IWarehouseProductService, IScopedLifescope
{
}
