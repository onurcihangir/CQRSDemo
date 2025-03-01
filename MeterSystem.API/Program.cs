using AutoMapper;
using CqrsMediatR.Mapper;
using MeterSystem.Infrastructure;
using MeterSystem.Infrastructure.Abstract;
using MeterSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddDbContext<PostgreDbContext>(db =>
    db.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionString")), ServiceLifetime.Singleton);

builder.Services.AddScoped<IConsumptionRepository, ConsumptionRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var config = new MapperConfiguration(conf =>
{
    conf.AddProfile<RegisterMapper>();
});
builder.Services.AddScoped(s => config.CreateMapper());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PostgreDbContext>();
    context.EnsureHyperTable();
}

app.MapGet("/", () => "Hello World!");

app.Run();
