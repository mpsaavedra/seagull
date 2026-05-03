using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Products;

public interface IProductRepository: IRepository<Product>
{
    
}

public class ProductRepository : Repository<Product, ApplicationDbContext>, IProductRepository, IScopedLifescope
{
    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
