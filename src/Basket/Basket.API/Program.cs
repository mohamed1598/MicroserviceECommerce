using Basket.API.Data;
using Basket.API.Data.Interfaces;
using Basket.API.GrpcServices;
using Basket.API.Helpers;
using Basket.API.Repositories;
using Basket.API.Repositories.Interfaces;
using Discount.GRPC.Protos;
using EventBusRabbitMQ;
using EventBusRabbitMQ.Producer;
using RabbitMQ.Client;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ConnectionMultiplexer>(sp =>
{
    var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis")!, true);
    return ConnectionMultiplexer.Connect(configuration);
});
builder.Services.AddTransient<IBasketContext, BasketContext>();
builder.Services.AddTransient<IBasketRepository, BasketRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
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
builder.Services.AddSingleton<EventBusRabbitMQProducer>();
builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>( o => o.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]!))
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
		var handler = new HttpClientHandler
		{
			ServerCertificateCustomValidationCallback =
			HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
		};

		return handler;
    });
builder.Services.AddScoped<DiscountGrpcService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
