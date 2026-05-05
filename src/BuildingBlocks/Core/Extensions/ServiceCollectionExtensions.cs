using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Seagull.Extensions;

/// <summary>
/// Service collection related extensions
/// </summary>
public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddSeagullServices(this WebApplicationBuilder builder)
    {
        var config = builder.Configuration;

        builder.AddServiceDefaults();

        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opts =>
            {
                opts.RequireHttpsMetadata = false;
                opts.Audience = config["Authorization:Audience"];
                opts.MetadataAddress = config["Authorization:MetadataAddress"]!;
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer =  config["Authorization:ValidIssuer"],
                    ClockSkew = TimeSpan.Zero
                };
            });
        // builder.Services.AddCors();

        builder.Services.AddSwaggerGen();

        return builder;
    }

    public static WebApplication UseSeagullServices(this WebApplication app)
    {
        if(app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseHttpsRedirection();       
        }

        // app.UseCors(cfg =>
        // cfg
        //     .AllowAnyOrigin()
        //     .AllowAnyHeader()
        //     .AllowAnyMethod()
        //     .WithOrigins(config["CorsOrigins"]));
        app.MapDefaultEndpoints();
        app.UseAuthentication();
        app.UseAuthorization();

        if(app.Environment.IsDevelopment())
        {
            // redirect to swagger
            app.MapGet("/", async _ => Results.Redirect("/swagger"));
        }

        return app;
    }
}
