namespace SwashbuckleVsNSwag.Features.ToDoList.DTOs;

public class ToDoItemPostDto
{
    public required string Title { get; init; }

    public TimeSpan DueIn { get; init; }
}
