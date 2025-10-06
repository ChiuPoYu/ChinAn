using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Services;
using WebApi.Interfaces;
using Microsoft.Extensions.Configuration.Json;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// µù¥U DbContext
var mssqlSection = builder.Configuration
    .GetSection("WriteTo")
    .GetChildren()
    .FirstOrDefault(x => x.GetValue<string>("Name") == "MSSQL");
var connectionString = mssqlSection?.GetSection("Args")?.GetValue<string>("ConnectionString");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// µù¥U Service
builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();

// CORS for Vite dev servers and local clients
var corsPolicyName = "AllowLocalDev";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName, policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:5173", // Vite default (UserWeb)
                "http://localhost:5174", // another Vite port if needed
                "http://localhost:3000"   // matches current API_BASE_URL origin in UserWeb
            )
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
