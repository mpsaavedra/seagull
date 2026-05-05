using System;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Categories;

public interface ICategoryRepository: IRepository<Category>
{
    
}

public class CategoryRepository : Repository<Category, ApplicationDbContext>, ICategoryRepository, IScopedLifescope
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
