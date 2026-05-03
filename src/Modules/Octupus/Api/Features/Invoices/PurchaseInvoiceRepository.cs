using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Invoices;

public interface IPurchaseInvoiceRepository : IRepository<PurchaseInvoice>
{
    
}

public class PurchaseInvoiceRepository : Repository<PurchaseInvoice, ApplicationDbContext>, IPurchaseInvoiceRepository, IScopedLifescope
{
    public PurchaseInvoiceRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
