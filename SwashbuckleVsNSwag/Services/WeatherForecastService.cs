using Microsoft.AspNetCore.Mvc;
using SwashbuckleVsNSwag.DTOs;

namespace SwashbuckleVsNSwag.Services;

public class WeatherForecastService : ControllerBase
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastService> _logger;

    public WeatherForecastService(ILogger<WeatherForecastService> logger)
    {
        _logger = logger;
    }
    
    public IEnumerable<WeatherForecastDto> Get()
    {
        return Enumerable.Range(1, 5)
            .Select(index => new WeatherForecastDto
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });
    }
}
