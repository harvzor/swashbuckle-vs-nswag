namespace SwashbuckleVsNSwag.Swashbuckle;

public static class SetupSwashbuckle
{
    public static IServiceCollection SetupSwashbuckleServices(this IServiceCollection services)
    {
        services.AddMvc();

        services.AddSwaggerGen();
        
        return services;
    }

    public static WebApplication SetupSwashbuckleApp(this WebApplication app)
    {
        app.UseSwagger();
        
        app.UseSwaggerUI();
        
        return app;
    }
}
