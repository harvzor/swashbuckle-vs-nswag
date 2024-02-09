using Microsoft.AspNetCore.Mvc;
using SwashbuckleVsNSwag.Features.WeatherForecast.DTOs;

namespace SwashbuckleVsNSwag.Features.WeatherForecast.Services;

public class WeatherForecastService : ControllerBase
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public IEnumerable<WeatherForecastDto> Get()
    {
        return Enumerable.Range(1, 5)
            .Select(index =>
            {
                var timeSpan = TimeSpan.FromDays(index);
                
                return new WeatherForecastDto
                {
                    Date = DateTime.Now.Add(timeSpan),
                    Offset = timeSpan,
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                };
            });
    }
}
