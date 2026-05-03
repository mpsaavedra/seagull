using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Customers;

public interface ICustomerRepository : IRepository<Customer>
{
    
}

public class CustomerRepository : Repository<Customer, ApplicationDbContext>, ICustomerRepository, IScopedLifescope
{
    public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
