using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot();
builder.Configuration.AddJsonFile("ocelot.json",
        optional: false,
        reloadOnChange: true);


var app = builder.Build();
await app.UseOcelot();

app.MapGet("/", () => "Ocelot Working!");

app.Run();
