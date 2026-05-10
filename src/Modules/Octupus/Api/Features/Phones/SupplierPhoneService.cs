using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Phones;

public interface ISupplierPhoneService : IService<SupplierPhone>
{

}

public class SupplierPhoneService(ApplicationDbContext dbContext, IMapper mapper, ILogger<SupplierPhoneService> logger) :
    Service<SupplierPhone, ApplicationDbContext>(dbContext, mapper, logger), ISupplierPhoneService, IScopedLifescope
{
}
