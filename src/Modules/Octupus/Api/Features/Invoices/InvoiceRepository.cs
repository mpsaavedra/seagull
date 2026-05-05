using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Invoices;

public interface IInvoiceRepository: IRepository<Invoice>
{
    
}

public class InvoiceRepository : Repository<Invoice, ApplicationDbContext>, IInvoiceRepository, IScopedLifescope
{
    public InvoiceRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
