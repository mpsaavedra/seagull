using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Payments;

public interface IPurchasePaymentRepository : IRepository<PurchasePayment>
{
    
}
public class PurchaseRepository : Repository<PurchasePayment, ApplicationDbContext>, IPurchasePaymentRepository, IScopedLifescope
{
    public PurchaseRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
