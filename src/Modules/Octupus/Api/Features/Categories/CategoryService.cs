using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Categories;

public interface ICategoryService : IService<Category>
{

}

public class CategoryService(ApplicationDbContext dbContext, IMapper mapper, ILogger<CategoryService> logger) :
    Service<Category, ApplicationDbContext>(dbContext, mapper, logger), ICategoryService, IScopedLifescope
{
}
