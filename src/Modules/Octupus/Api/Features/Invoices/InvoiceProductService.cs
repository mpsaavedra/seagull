using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Invoices;

public interface IInvoiceProductService : IService<InvoiceProduct>
{

}

public class InvoiceProductService(ApplicationDbContext dbContext, IMapper mapper, ILogger<InvoiceProductService> logger) :

    Service<InvoiceProduct, ApplicationDbContext>(dbContext, mapper, logger), IInvoiceProductService, IScopedLifescope
{
}
