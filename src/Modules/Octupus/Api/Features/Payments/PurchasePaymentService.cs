using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Payments;

public interface IPurchasePaymentService : IService<PurchasePayment>
{

}

public class PurchasePaymentService(ApplicationDbContext dbContext, IMapper mapper, ILogger<PurchasePaymentService> logger) :
    Service<PurchasePayment, ApplicationDbContext>(dbContext, mapper, logger), IPurchasePaymentService, IScopedLifescope
{
}
