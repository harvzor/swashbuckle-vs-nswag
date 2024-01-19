using Microsoft.AspNetCore.Mvc;
using SwashbuckleVsNSwag.DTOs;
using SwashbuckleVsNSwag.Services;

namespace SwashbuckleVsNSwag.Controllers;

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
