using SwashbuckleVsNSwag;
using SwashbuckleVsNSwag.NSwag;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .SetupBaseServices()
    .SetupNSwagServices();

var app = builder.Build();

app = app
    .SetupBaseApp()
    .SetupNSwagApp();

app.Run();
