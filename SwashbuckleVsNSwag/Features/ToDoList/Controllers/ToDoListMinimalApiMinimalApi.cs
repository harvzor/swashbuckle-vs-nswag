using Microsoft.AspNetCore.Mvc;
using SwashbuckleVsNSwag.Features.ToDoList.DTOs;
using SwashbuckleVsNSwag.Features.ToDoList.Mappers;
using SwashbuckleVsNSwag.Features.ToDoList.Services;

namespace SwashbuckleVsNSwag.Features.ToDoList.Controllers;

public static class ToDoListMinimalApi
{
    public static void MapToDoListMinimalApi(this WebApplication app)
    {
        var group = app.MapGroup("/ToDoListMinimalApi");

        group
            .MapGet("/",
                ([FromServices] ToDoListService toDoListService) => toDoListService.Get().Map())
            // Requires Microsoft.AspNetCore.OpenApi.
            .WithOpenApi();
        
        group
            .MapPost("/",
                ([FromServices] ToDoListService toDoListService, ToDoItemPostDto toDoItemPostDto) => toDoListService.Create(toDoItemPostDto).Map())
            // Requires Microsoft.AspNetCore.OpenApi.
            .WithOpenApi();
    }
}
