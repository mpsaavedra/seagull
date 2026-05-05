using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi;
using Seagull.Data;

namespace Seagull.Plugins.ScripEngines.Lua;

public class PluginDataBridge
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<PluginDataBridge> _logger;

    public PluginDataBridge(IServiceProvider serviceProvider, ILogger<PluginDataBridge> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    // public object GetProduct(int id)
    // {
    //     using var scope = _serviceProvider.CreateScope();
    //     var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    //     // Return a simplified object or a DTO
    //     return db.Products.FirstOrDefault(p => p.Id == id);
    // }

    // public void UpdatePrice(int productId, decimal newPrice)
    // {
    //     using var scope = _serviceProvider.CreateScope();
    //     var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    //     var product = db.Products.Find(productId);
    //     if (product != null)
    //     {
    //         product.Price = newPrice;
    //         db.SaveChanges(); // C# handles the transaction
    //         _logger.LogInformation($"Price updated by script for Product {productId}");
    //     }
    // }

    public IRepository<TEntity> GetRespositorGetUoW<TEntity>()
        where TEntity: Entity
    {
        using var scope = _serviceProvider.CreateScope();
        var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        return uow.Repository<TEntity>();
    }
}
