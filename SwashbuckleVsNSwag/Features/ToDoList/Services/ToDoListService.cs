using SwashbuckleVsNSwag.Features.ToDoList.DTOs;
using SwashbuckleVsNSwag.Features.ToDoList.Models;

namespace SwashbuckleVsNSwag.Features.ToDoList.Services;

public class ToDoListService
{
    private List<ToDoItemModel> _todoItems = new();

    public IEnumerable<ToDoItemModel> Get()
    {
        return _todoItems;
    }
    
    public ToDoItemModel Create(ToDoItemPostDto toDoItemPostDto)
    {
        var now = DateTimeOffset.Now;
        var nowToTheClosestSecond = new DateTimeOffset(
            now.Year,
            now.Month,
            now.Day, now.Hour,
            now.Minute,
            now.Second,
            now.Offset
        );
        
        ToDoItemModel toDoItemModel = new()
        {
            Id = _todoItems.Count + 1,
            Title = toDoItemPostDto.Title,
            Done = false,
            DueDateTime = nowToTheClosestSecond.Add(toDoItemPostDto.DueIn)
        };
        
        _todoItems
            .Add(toDoItemModel);

        return toDoItemModel;
    }
}
