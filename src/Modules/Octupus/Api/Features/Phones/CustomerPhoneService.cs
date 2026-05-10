using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Phones;

public interface ICustomerPhoneService : IService<CustomerPhone>
{

}

public class CustomerPhoneService(ApplicationDbContext dbContext, IMapper mapper, ILogger<CustomerPhoneService> logger) :
    Service<CustomerPhone, ApplicationDbContext>(dbContext, mapper, logger), ICustomerPhoneService, IScopedLifescope
{
}
