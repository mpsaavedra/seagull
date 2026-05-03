using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Payments;

public interface ISalePaymentRepository : IRepository<SalePayment>
{
}

public class SalePaymentRepository : Repository<SalePayment, ApplicationDbContext>, ISalePaymentRepository, IScopedLifescope
{
    public SalePaymentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
