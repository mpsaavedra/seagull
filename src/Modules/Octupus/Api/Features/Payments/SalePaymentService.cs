using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Payments;

public interface ISalePaymentService : IService<SalePayment>
{

}

public class SalePaymentService(ApplicationDbContext dbContext, IMapper mapper, ILogger<SalePaymentService> logger) :
    Service<SalePayment, ApplicationDbContext>(dbContext, mapper, logger), ISalePaymentService, IScopedLifescope
{
}
