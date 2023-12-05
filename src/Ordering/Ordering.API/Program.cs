using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Handlers;
using Ordering.Application.Mapper;
using Ordering.Core.Repositories;
using Ordering.Core.Repositories.Base;
using Ordering.Infrastracture.Data;
using Ordering.Infrastracture.Repositories;
using Ordering.Infrastracture.Repositories.Base;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<OrderContext>(c =>
{
    c.UseSqlServer(builder.Configuration.GetConnectionString("OrderConnection"));
},ServiceLifetime.Singleton);
builder.Services.AddAutoMapper(typeof(OrderMappingProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CheckoutOrderHandler).Assembly));

builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<OrderContext>();
        await OrderContextSeed.SeedAsync(context, loggerFactory);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occured during migration");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
