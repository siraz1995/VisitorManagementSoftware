using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath).AddJsonFile("ocelot.json", optional: false, reloadOnChange: true).AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);
app.MapControllers();
await app.UseOcelot();
app.Run();
