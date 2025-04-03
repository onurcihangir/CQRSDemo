using AutoMapper;
using CqrsMediatR.Mapper;
using MeterSystem.Application.Handlers;
using MeterSystem.Infrastructure.Abstract;
using MeterSystem.Infrastructure.Repositories;
using MeterSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetUserByIdQueryHandler>());

builder.Services.AddDbContext<PostgreDbContext>(db =>
    db.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionString"), options => options.MigrationsAssembly("MeterSystem.Infrastructure")));

builder.Services.AddScoped<IConsumptionRepository, ConsumptionRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var config = new MapperConfiguration(conf =>
{
    conf.AddProfile<RegisterMapper>();
});
builder.Services.AddScoped(s => config.CreateMapper());
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.Run();
