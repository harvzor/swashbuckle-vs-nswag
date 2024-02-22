using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using Harvzor.Optional.SystemTextJson;
using SwashbuckleVsNSwag.Features.OptionalTest.Controllers;
using SwashbuckleVsNSwag.Features.OptionalTest.Services;
using SwashbuckleVsNSwag.Features.ToDoList.Controllers;
using SwashbuckleVsNSwag.Features.ToDoList.Services;
using SwashbuckleVsNSwag.Features.WeatherForecast.Controllers;
using SwashbuckleVsNSwag.Features.WeatherForecast.Services;

namespace SwashbuckleVsNSwag;

public static class SetupBase
{
    public static IServiceCollection SetupBaseServices(this IServiceCollection services)
    {
        services.AddControllers();
        
        // Necessary to make Swashbuckle and NSwag work with Minimal APIs and Microsoft.AspNetCore.OpenApi.
        services.AddEndpointsApiExplorer();

        services.AddScoped<WeatherForecastService>();
        // Internally has an in memory datastore which should be shared between sessions.
        services.AddSingleton<ToDoListService>();
        services.AddScoped<OptionalTestService>();
        
        // Minimal APIs:
        services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options
            => ConfigureJsonSerializerOptions(options.SerializerOptions)
        );
        
        // Controller configuration:
        services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options
            => ConfigureJsonSerializerOptions(options.JsonSerializerOptions)
        );

        return services;
    }

    public static WebApplication SetupBaseApp(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.MapControllers();

        app.MapWeatherForecastMinimalApi();
        app.MapToDoListMinimalApi();
        app.MapOptionalTestMinimalApi();

        return app;
    }

    private static void ConfigureJsonSerializerOptions(JsonSerializerOptions options)
    {
        options.Converters.Add(new OptionalJsonConverter());
        options.TypeInfoResolver = new DefaultJsonTypeInfoResolver
        {
            Modifiers = { OptionalTypeInfoResolverModifiers.IgnoreUndefinedOptionals }
        };
    }
}
