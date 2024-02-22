using Microsoft.AspNetCore.Mvc;
using SwashbuckleVsNSwag.Features.OptionalTest.DTOs;
using SwashbuckleVsNSwag.Features.OptionalTest.Services;

namespace SwashbuckleVsNSwag.Features.OptionalTest.Controllers;

public static class OptionalTestMinimalApi
{
    public static void MapOptionalTestMinimalApi(this WebApplication app)
    {
        var group = app.MapGroup("/OptionalTestMinimalApi");

        group
            .MapPost("/",
                ([FromServices] OptionalTestService optionalTestService, OptionalTestDto optionalTestDto) => optionalTestService.Create(optionalTestDto))
            // Requires Microsoft.AspNetCore.OpenApi.
            .WithOpenApi();
    }
}
