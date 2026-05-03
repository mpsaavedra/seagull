using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Suppliers;

public interface ISupplierRepository: IRepository<Supplier>
{
    
}

public class SupplierRepository : Repository<Supplier, ApplicationDbContext>, ISupplierRepository, IScopedLifescope
{
    public SupplierRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
