using System.Reflection;
using Serilog;
using Service1.Configuration;
using Service1.Extensions;
using Service1.Models;
using Service1.Repositories;
using Service1.Repositories.Contracts;
using Service1.Services;
using Service1.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.Configure<DataStore>(builder.Configuration.GetSection("DataStore"));
    builder.Services.Configure<CacheConfigure>(builder.Configuration.GetSection("CacheConfigure"));
    builder.Services.AddScoped<RepositoryContext>();
    builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
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