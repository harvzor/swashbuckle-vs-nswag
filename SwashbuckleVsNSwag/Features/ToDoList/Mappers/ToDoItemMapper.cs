using SwashbuckleVsNSwag.Features.ToDoList.DTOs;
using SwashbuckleVsNSwag.Features.ToDoList.Models;

namespace SwashbuckleVsNSwag.Features.ToDoList.Mappers;

public static class ToDoItemMapper
{
    public static ToDoItemModel Map(this TodoItemResponseDto responseDto) => new()
    {
        Title = responseDto.Title,
        Done = responseDto.Done,
        DueDateTime = responseDto.DueDateTime
    };

    public static TodoItemResponseDto Map(this ToDoItemModel dto) => new()
    {
        Id = dto.Id,
        Title = dto.Title,
        Done = dto.Done,
        DueDateTime = dto.DueDateTime
    };
    
    public static IEnumerable<TodoItemResponseDto> Map(this IEnumerable<ToDoItemModel> dtos) =>
        dtos.Select(dto => dto.Map());
}
