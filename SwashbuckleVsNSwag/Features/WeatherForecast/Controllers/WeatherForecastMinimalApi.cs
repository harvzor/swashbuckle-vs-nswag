using Microsoft.AspNetCore.Mvc;
using SwashbuckleVsNSwag.Features.WeatherForecast.Services;

namespace SwashbuckleVsNSwag.Features.WeatherForecast.Controllers;

public static class WeatherForecastMinimalApi
{
    public static void MapWeatherForecastMinimalApi(this WebApplication app)
    {
        var group = app.MapGroup("/WeatherForecastMinimalApi");

        group
            .MapGet("/",
                ([FromServices] WeatherForecastService weatherForecastService) => weatherForecastService.Get())
            // Requires Microsoft.AspNetCore.OpenApi.
            .WithOpenApi();
    }
}
