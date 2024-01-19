using Microsoft.AspNetCore.Mvc;
using SwashbuckleVsNSwag.Services;

namespace SwashbuckleVsNSwag.Controllers;

public static class WeatherForecastMinimalApi
{
    public static void MapWeatherForecastMinimalApi(this WebApplication app)
    {
        var group = app.MapGroup("/weatherforecastminimalapi");

        group
            .MapGet("/",
                ([FromServices] WeatherForecastService weatherForecastService) => weatherForecastService.Get())
            // Requires Microsoft.AspNetCore.OpenApi.
            .WithOpenApi();
    }
}
