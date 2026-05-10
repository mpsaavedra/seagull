using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Phones;

public interface IWarehousePhoneService : IService<WarehousePhone>
{

}

public class WarehousePhoneService(ApplicationDbContext dbContext, IMapper mapper, ILogger<WarehousePhoneService> logger) :
    Service<WarehousePhone, ApplicationDbContext>(dbContext, mapper, logger), IWarehousePhoneService, IScopedLifescope
{
}
