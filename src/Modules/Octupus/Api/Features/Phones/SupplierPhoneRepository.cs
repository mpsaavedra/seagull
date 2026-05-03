using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Phones;

public interface ISupplierPhoneRepository : IRepository<SupplierPhone>
{
    
}

public class SupplierPhoneRepository : Repository<SupplierPhone, ApplicationDbContext>, ISupplierPhoneRepository, IScopedLifescope
{
    public SupplierPhoneRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
