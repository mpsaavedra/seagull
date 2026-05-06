using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi;
using Seagull.Data;

namespace Seagull.Plugins.ScripEngines.Lua;

public interface IPLuginDataBridge
{
    void LogInfo(string msg);
}

public class PluginDataBridge : IPLuginDataBridge
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

    public dynamic GetProduct(string id)
    {
        return $"This is suppoused to return the address with id '{id}'.";
    }

    public void LogInfo(string msg)
    {
        _logger.LogInformation($"[LUA_HOST]: {msg}");
        Console.WriteLine($"[LUA_HOST]: {msg}");
    }
}
