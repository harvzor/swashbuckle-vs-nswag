using Microsoft.AspNetCore.Mvc;
using SwashbuckleVsNSwag.Features.WeatherForecast.DTOs;
using SwashbuckleVsNSwag.Features.WeatherForecast.Services;

namespace SwashbuckleVsNSwag.Features.WeatherForecast.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly WeatherForecastService _weatherForecastService;

    public WeatherForecastController(WeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    public IEnumerable<WeatherForecastDto> Get() => _weatherForecastService.Get();
}
