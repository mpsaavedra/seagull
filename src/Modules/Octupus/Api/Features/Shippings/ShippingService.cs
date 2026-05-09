using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Shippings;

public interface IShippingService : IService<Shipping>
{

}

public class ShippingService(ApplicationDbContext dbContext, IMapper mapper, ILogger<ShippingService> logger) :
    Service<Shipping, ApplicationDbContext>(dbContext, mapper, logger), IShippingService, IScopedLifescope
{
}
