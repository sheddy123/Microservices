using PlatformService.Extensions.Program;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.RegisterApplicationServices(configuration);

var app = builder.Build();

app.ConfigureMiddleWare();
app.RegisterEndpoints();

app.Run();
