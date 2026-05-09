using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Warehouses;

public interface IWarehouseService : IService<Warehouse>
{
}

public class WarehouseService(ApplicationDbContext dbContext, IMapper mapper, ILogger<WarehouseService> logger) :
    Service<Warehouse, ApplicationDbContext>(dbContext, mapper, logger), IWarehouseService, IScopedLifescope
{
}
