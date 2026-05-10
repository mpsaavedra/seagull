using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Payments;

public interface IStandSalePaymentService : IService<StandSalePayment>
{

}

public class StandSalePaymentService(ApplicationDbContext dbContext, IMapper mapper, ILogger<StandSalePaymentService> logger) :
    Service<StandSalePayment, ApplicationDbContext>(dbContext, mapper, logger), IStandSalePaymentService, IScopedLifescope
{
}
