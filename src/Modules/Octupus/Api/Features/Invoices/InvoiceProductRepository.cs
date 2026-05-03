using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Invoices;

public interface IInvoiceProductRepository : IRepository<InvoiceProduct>
{
    
}

public class InvoiceProductRepository : Repository<InvoiceProduct, ApplicationDbContext>, IInvoiceProductRepository, IScopedLifescope
{
    public InvoiceProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
