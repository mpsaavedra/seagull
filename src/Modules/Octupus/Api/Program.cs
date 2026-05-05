using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Octupus.Api;
using Octupus.Api.Data;
using Octupus.Api.Features.Addresses;
using Seagull.Data;
using Seagull.Extensions;

var builder = WebApplication.CreateBuilder(args);

// install all general services required by API
builder.InstallOctupusServices<ApplicationDbContext>(opts =>
    opts
        .EnableDetailedErrors(builder.Environment.IsDevelopment())
        .EnableSensitiveDataLogging(builder.Environment.IsDevelopment())
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), cfg =>
            cfg
                .MigrationsAssembly("Octupus.Api")
                .EnableRetryOnFailure(10, TimeSpan.FromSeconds(10), null))); 

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}

// include in the pipeline all general services required by API
app.UseOctupusServices();

app.Run();
