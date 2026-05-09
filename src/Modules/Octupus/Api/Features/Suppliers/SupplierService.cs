using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Suppliers;

public interface ISupplierService : IService<Supplier>
{

}
public class SupplierService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) :
    Service<Supplier, ApplicationDbContext>(dbContext, mapper, logger), ISupplierService, IScopedLifescope
{
}
