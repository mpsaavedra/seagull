using Microsoft.EntityFrameworkCore;
using Octupus.Api.Data;
using Seagull.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddSeagullServices();
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts
        .EnableDetailedErrors(builder.Environment.IsDevelopment())
        .EnableSensitiveDataLogging(builder.Environment.IsDevelopment())
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), cfg =>
            cfg
                .MigrationsAssembly("Octupus.Api")
                .EnableRetryOnFailure(10, TimeSpan.FromSeconds(10), null)));
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSeagullServices();

app.Run();
