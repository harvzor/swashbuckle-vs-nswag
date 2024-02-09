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
