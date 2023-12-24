using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());
builder.Configuration.AddJsonFile("ocelot.json",
        optional: false,
        reloadOnChange: true);


var app = builder.Build();
await app.UseOcelot();

app.MapGet("/", () => "Ocelot Working!");

app.Run();
