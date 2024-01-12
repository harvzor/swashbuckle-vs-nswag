namespace SwashbuckleVsNSwag.NSwag;

public static class SetupNSwag
{
    public static IServiceCollection SetupNSwagServices(this IServiceCollection services)
    {
        services.AddOpenApiDocument(); // add OpenAPI v3 document
        // services.AddSwaggerDocument(); // add Swagger v2 document

        return services;
    }

    public static WebApplication SetupNSwagApp(this WebApplication app)
    {
        app.UseOpenApi(); // serve OpenAPI/Swagger documents
        app.UseSwaggerUi(); // serve Swagger UI
        // app.UseReDoc(); // serve ReDoc UI

        return app;
    }
}
