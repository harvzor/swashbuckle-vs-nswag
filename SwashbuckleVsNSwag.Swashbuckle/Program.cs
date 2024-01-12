using SwashbuckleVsNSwag;
using SwashbuckleVsNSwag.Swashbuckle;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .SetupBaseServices()
    .SetupSwashbuckleServices();

var app = builder.Build();

app = app
    .SetupBaseApp()
    .SetupSwashbuckleApp();

app.Run();
