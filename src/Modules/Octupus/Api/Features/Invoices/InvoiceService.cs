using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Invoices;

public interface IInvoiceService : IService<Invoice>
{

}

public class InvoiceService(ApplicationDbContext dbContext, IMapper mapper, ILogger<InvoiceService> logger) :
    Service<Invoice, ApplicationDbContext>(dbContext, mapper, logger), IInvoiceService, IScopedLifescope
{
}
