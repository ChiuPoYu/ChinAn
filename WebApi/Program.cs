using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using System.Reflection;
using WebApi.Models.DBModels;
using WebApi.Repositories;
using WebApi.Repositories.Interfaces;
using WebApi.Resources;
using WebApi.Services.App;
using WebApi.Services.Interfaces.App;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 註冊 DbContext
var connectionString = builder.Configuration.GetValue<string>(AppSettingsKey.DBConnection);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// 註冊 Service
builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();

// 註冊Repositories
builder.Services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});


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
//TODO: 暫時開放swagger，之後前端寫好框架後再鎖住
app.UseSwagger();
app.UseSwaggerUI();

// Disable HTTPS redirection to simplify local dev with plain HTTP
// app.UseHttpsRedirection();

app.UseCors(corsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
