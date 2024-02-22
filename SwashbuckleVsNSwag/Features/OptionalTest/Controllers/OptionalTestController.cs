using Microsoft.AspNetCore.Mvc;
using SwashbuckleVsNSwag.Features.OptionalTest.DTOs;
using SwashbuckleVsNSwag.Features.OptionalTest.Services;

namespace SwashbuckleVsNSwag.Features.OptionalTest.Controllers;

[ApiController]
[Route("[controller]")]
public class OptionalTestController : ControllerBase
{
    private readonly OptionalTestService _optionalTestService;

    public OptionalTestController(OptionalTestService optionalTestService)
    {
        _optionalTestService = optionalTestService;
    }

    [HttpPost]
    public OptionalTestDto Post(OptionalTestDto optionalTestDto) => _optionalTestService.Create(optionalTestDto);
}
