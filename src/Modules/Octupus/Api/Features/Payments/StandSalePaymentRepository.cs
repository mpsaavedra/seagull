using System;
using Octupus.Api.Data;
using Octupus.Api.Features.Sales;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Payments;

public interface IStandSalePaymentRepository : IRepository<StandSalePayment>
{
    
}

public class StandSalePaymentRepository : Repository<StandSalePayment, ApplicationDbContext>, IStandSalePaymentRepository, IScopedLifescope
{
    public StandSalePaymentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
