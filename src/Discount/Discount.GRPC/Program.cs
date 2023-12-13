using Discount.GRPC.Extensions;
using Discount.GRPC.Mapping;
using Discount.GRPC.Repositories;
using Discount.GRPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDiscountRepository,DiscountRepository>();
builder.Services.AddAutoMapper(typeof(DiscountProfile));
builder.Services.AddGrpc();

var app = builder.Build();
app.MigrateDatabase<Program>();

// Configure the HTTP request pipeline.
app.MapGrpcService<DiscountService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
