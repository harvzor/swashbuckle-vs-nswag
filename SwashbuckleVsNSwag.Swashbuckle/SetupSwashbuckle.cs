using Harvzor.Optional;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace SwashbuckleVsNSwag.Swashbuckle;

public static class SetupSwashbuckle
{
    public static IServiceCollection SetupSwashbuckleServices(this IServiceCollection services)
    {
        services.AddMvc();
        
        services.AddSwaggerGen(options =>
        {
            // https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2505#issuecomment-1279557743
            options.MapType<TimeSpan?>(() => new OpenApiSchema
            {
                Type = "string",
                Nullable = true,
                Example = new OpenApiString("00:00:00")
            });
            
            options.MapType<TimeSpan>(() => new OpenApiSchema
            {
                Type = "string",
                Example = new OpenApiString("00:00:00")
            });
            
            // Checking if open generics are supported:
            // options.MapType(typeof(Optional<>), () =>
            // {
            //     // I need to know what type is currently being mapped so I can dynamically return the schema.
            //     // e.g., if the type is `Optional<string?>`, return a string
            //     
            //     return new OpenApiSchema
            //     {
            //         Type = "string",
            //         Nullable = true
            //     };
            // });
            
            // Manually mapping generics:
            options.MapType(typeof(Optional<string?>), () => new OpenApiSchema
            {
                Type = "string",
                // Nullable appears to be ignored:
                Nullable = true
            });
        });
        
        return services;
    }

    public static WebApplication SetupSwashbuckleApp(this WebApplication app)
    {
        app.UseSwagger();
        
        app.UseSwaggerUI();
        
        return app;
    }
}
