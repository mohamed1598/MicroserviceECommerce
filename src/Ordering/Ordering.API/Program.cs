using EventBusRabbitMQ;
using Microsoft.EntityFrameworkCore;
using Ordering.API.Extenstions;
using Ordering.API.Mapping;
using Ordering.API.RabbitMQ;
using Ordering.Application.Handlers;
using Ordering.Core.Repositories;
using Ordering.Core.Repositories.Base;
using Ordering.Infrastracture.Data;
using Ordering.Infrastracture.Repositories;
using Ordering.Infrastracture.Repositories.Base;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<OrderContext>(c =>
{
    c.UseSqlServer(builder.Configuration.GetConnectionString("OrderConnection"));
},ServiceLifetime.Singleton);
builder.Services.AddAutoMapper(typeof(OrderMapping));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CheckoutOrderHandler).Assembly));

builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddSingleton(typeof(IOrderRepository), typeof(OrderRepository));
builder.Services.AddSingleton<IRabbitMQConnection>(
                sp =>
                {
                    var factory = new ConnectionFactory()
                    {
                        HostName = builder.Configuration["EventBus:HostName"]
                    };

                    if (!string.IsNullOrEmpty(builder.Configuration["EventBus:UserName"]))
                    {
                        factory.UserName = builder.Configuration["EventBus:UserName"];
                    }
                    if (!string.IsNullOrEmpty(builder.Configuration["EventBus:Password"]))
                    {
                        factory.Password = builder.Configuration["EventBus:Password"];
                    }

                    return new RabbitMQConnection(factory);

                }
                );
builder.Services.AddSingleton<EventBusRabbitMQConsumer>();
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
app.UseRabbitListener();
app.Run();
