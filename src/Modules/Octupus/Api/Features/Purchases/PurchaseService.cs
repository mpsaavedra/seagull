using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Purchases;

public interface IPurchaseService : IService<Purchase>
{

}

public class PurchaseService(ApplicationDbContext dbContext, IMapper mapper, ILogger<PurchaseService> logger) :
    Service<Purchase, ApplicationDbContext>(dbContext, mapper, logger), IPurchaseService, IScopedLifescope
{
}
