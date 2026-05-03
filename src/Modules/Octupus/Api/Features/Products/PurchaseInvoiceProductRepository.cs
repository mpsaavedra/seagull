using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Products;

public interface IPurchaseInvoiceProductRepository: IRepository<PurchaseInvoiceProduct>
{
    
}

public class PurchaseInvoiceProductRepository : Repository<PurchaseInvoiceProduct, ApplicationDbContext>, IPurchaseInvoiceProductRepository, IScopedLifescope
{
    public PurchaseInvoiceProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
