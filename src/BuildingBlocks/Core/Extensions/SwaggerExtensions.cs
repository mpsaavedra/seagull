using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;

namespace Seagull.Extensions;

/// <summary>
/// Swagger related extensions
/// </summary>
public static class SwaggerExtensions
{
    public static IServiceCollection AddNekoSwaggerServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen();

        return services;
    }

    public static WebApplication UseNekoSwaggerServices(this WebApplication app, IConfiguration configuration)
    {
        app.UseSwagger();
        app.MapSwagger();
        
        return app;
    }
}
