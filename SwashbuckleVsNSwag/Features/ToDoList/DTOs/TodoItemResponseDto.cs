namespace SwashbuckleVsNSwag.Features.ToDoList.DTOs;

public class TodoItemResponseDto
{
    public int Id { get; init; }
    
    public required string Title { get; init; }

    public bool? Done { get; init; }

    public DateTimeOffset DueDateTime { get; init; }
}
