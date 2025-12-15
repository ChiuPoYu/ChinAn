using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Repositories.Interfaces;
using WebApi.Services;
using WebApi.Services.Interfaces;
using WebApi.Resources;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// µù¥U DbContext
var connectionString = builder.Configuration.GetValue<string>(AppSettingsKey.DBConnection);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// µù¥U Service
builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();

// µù¥URepositories
builder.Services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();


// CORS for Vite dev servers and local clients
var allowOrigins = builder.Configuration.GetSection(AppSettingsKey.AllowedOrigins).Get<string[]>();
var corsPolicyName = builder.Configuration.GetValue<string>(AppSettingsKey.CorsPolicyName);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName, policy =>
    {
        policy
            .WithOrigins(allowOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Disable HTTPS redirection to simplify local dev with plain HTTP
// app.UseHttpsRedirection();

app.UseCors(corsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
