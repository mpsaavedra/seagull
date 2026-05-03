using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Phones;

public interface ICustomerPhoneRepository : IRepository<CustomerPhone>
{
    
}

public class CustomerPhoneRepository : Repository<CustomerPhone, ApplicationDbContext>, ICustomerPhoneRepository, IScopedLifescope
{
    public CustomerPhoneRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
