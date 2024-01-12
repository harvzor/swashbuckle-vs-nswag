using SwashbuckleVsNSwag;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .SetupBaseServices();

var app = builder.Build();

app = app
    .SetupBaseApp();

app.Run();
