using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Customers;

public interface ICustomerService : IService<Customer>
{

}

public class CustomerService(ApplicationDbContext dbContext, IMapper mapper, ILogger<CustomerService> logger) :
    Service<Customer, ApplicationDbContext>(dbContext, mapper, logger), ICustomerService, IScopedLifescope
{
}
