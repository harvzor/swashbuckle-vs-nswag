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
        services.AddSingleton<ToDoListService>();

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

        return app;
    }
}
