using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Products;

public interface IProductService : IService<Product>
{

}
public class ProductService(ApplicationDbContext dbContext, IMapper mapper, ILogger<ProductService> logger) :

    Service<Product, ApplicationDbContext>(dbContext, mapper, logger), IProductService, IScopedLifescope
{
}
