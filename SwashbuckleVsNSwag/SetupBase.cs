namespace SwashbuckleVsNSwag;

public static class SetupBase
{
    public static IServiceCollection SetupBaseServices(this IServiceCollection services)
    {
        services.AddControllers();

        return services;
    }

    public static WebApplication SetupBaseApp(this WebApplication app)
    {
        // app.MapGet("/", () => "Hello World!");

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.MapControllers();

        return app;
    }
}