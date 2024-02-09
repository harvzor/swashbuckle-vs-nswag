using NJsonSchema;
using NJsonSchema.Generation.TypeMappers;

namespace SwashbuckleVsNSwag.NSwag;

public static class SetupNSwag
{
    public static IServiceCollection SetupNSwagServices(this IServiceCollection services)
    {
        // add OpenAPI v3 document
        // services.AddOpenApiDocument();
        services.AddOpenApiDocument(configure =>
        {
            // https://github.com/RicoSuter/NJsonSchema/wiki/Type-Mappers
            // https://github.com/RicoSuter/NSwag/issues/3576#issuecomment-1132673087
            configure.SchemaSettings.TypeMappers.Add(new PrimitiveTypeMapper(typeof(TimeSpan?), schema =>
            {
                schema.Format = "string";
                schema.IsNullableRaw = true;
                schema.Type = JsonObjectType.String;
                schema.Example = "00:00:00";
            }));
            
            configure.SchemaSettings.TypeMappers.Add(new PrimitiveTypeMapper(typeof(TimeSpan), schema =>
            {
                schema.Format = "string";
                schema.Type = JsonObjectType.String;
                schema.Example = "00:00:00";
            }));
        });
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
