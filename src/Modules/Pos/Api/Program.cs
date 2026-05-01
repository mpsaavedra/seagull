using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Pos.Infrastructure;
using Seagull.Extensions;
using Seagull.Messaging;
using Seagull.Messaging.Wolverine;

var builder = WebApplication.CreateBuilder(args);

builder.AddSeagullServices(builder.Configuration);
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts
        .EnableDetailedErrors(builder.Environment.IsDevelopment())
        .EnableSensitiveDataLogging(builder.Environment.IsDevelopment())
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), cfg =>
            cfg
                .MigrationsAssembly("Pos.Api")
                .EnableRetryOnFailure(10, TimeSpan.FromSeconds(10), null)));
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // add some development only options
}

app.MapGet("/users/me", (ClaimsPrincipal claimsPrincipal) =>
{
    return claimsPrincipal.Claims.ToDictionary(c => c.Type, c => c.Value);
}).RequireAuthorization();

app.UseSeagullServices(app.Configuration);

app.Run();