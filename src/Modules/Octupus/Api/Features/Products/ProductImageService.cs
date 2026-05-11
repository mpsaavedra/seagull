using System;
using AutoMapper;
using Octupus.Api.Data;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Interfaces;

namespace Octupus.Api.Features.Products;

public interface IProductImageService : IService<ProductImage>
{

}
public class ProductImageService(ApplicationDbContext dbContext, IMapper mapper, ILogger<ProductImageService> logger) :
    Service<ProductImage, ApplicationDbContext>(dbContext, mapper, logger), IProductImageService, IScopedLifescope
{
}
