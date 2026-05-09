using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Sales;

public interface ISaleService : IService<Sale>
{

}
public class SaleService(ApplicationDbContext dbContext, IMapper mapper, ILogger<SaleService> logger) :
    Service<Sale, ApplicationDbContext>(dbContext, mapper, logger), ISaleService, IScopedLifescope
{
}
