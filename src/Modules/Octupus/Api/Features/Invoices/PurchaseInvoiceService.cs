using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Invoices;

public interface IPurchaseInvoiceService : IService<PurchaseInvoice>
{

}

public class PurchaseInvoiceService(ApplicationDbContext dbContext, IMapper mapper, ILogger<PurchaseInvoiceService> logger) :
    Service<PurchaseInvoice, ApplicationDbContext>(dbContext, mapper, logger), IPurchaseInvoiceService, IScopedLifescope
{
}
