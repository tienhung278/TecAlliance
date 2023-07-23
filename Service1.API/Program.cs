using System.Reflection;
using Serilog;
using Service1.API.Cache;
using Service1.API.Cache.Contracts;
using Service1.API.Configuration;
using Service1.API.Extensions;
using Service1.API.Models;
using Service1.API.Repositories;
using Service1.API.Repositories.Contracts;
using Service1.API.Services;
using Service1.API.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.Configure<DataStore>(builder.Configuration.GetSection("DataStore"));
    builder.Services.Configure<CacheConfigure>(builder.Configuration.GetSection("CacheConfigure"));
    builder.Services.AddScoped<IRepositoryContext, RepositoryContext>();
    builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
    builder.Services.AddScoped<ICacheManager, CacheManager>();
    builder.Services.AddScoped<ICacheContext, CacheContext>();
    builder.Services.AddScoped<IServiceManager, ServiceManager>();
    builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
    builder.Services.AddCors(CorsConfiguration.Configure);
    builder.Services.AddMemoryCache();
    builder.Host.UseSerilog(SeriLoggerConfiguration.Configure);
}

var app = builder.Build();
{
    app.UseGlobalException();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.UseCors();
    app.MapControllers();
    app.Run();
}