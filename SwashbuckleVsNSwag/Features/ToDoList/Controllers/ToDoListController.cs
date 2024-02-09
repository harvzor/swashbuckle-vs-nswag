using Microsoft.AspNetCore.Mvc;
using SwashbuckleVsNSwag.Features.ToDoList.DTOs;
using SwashbuckleVsNSwag.Features.ToDoList.Mappers;
using SwashbuckleVsNSwag.Features.ToDoList.Services;

namespace SwashbuckleVsNSwag.Features.ToDoList.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoListController : ControllerBase
{
    private readonly ToDoListService _toDoListService;

    public ToDoListController(ToDoListService toDoListService)
    {
        _toDoListService = toDoListService;
    }

    [HttpGet]
    public IEnumerable<TodoItemResponseDto> Get() => 
        _toDoListService
            .Get()
            .Map();

    [HttpPost]
    public TodoItemResponseDto Post(ToDoItemPostDto toDoItemPostDto) =>
        _toDoListService
            .Create(toDoItemPostDto)
            .Map();
}
