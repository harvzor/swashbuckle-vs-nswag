using System.Text.Json.Serialization;

namespace SwashbuckleVsNSwag.Features.ToDoList.DTOs;

public class TodoItemResponseDto
{
    public int Id { get; init; }
    
    public required string Title { get; init; }

    public bool? Done { get; init; }

    [System.Text.Json.Serialization.JsonPropertyName("due")] // Testing that the schema generation uses STJ properties.
    public DateTimeOffset DueDateTime { get; init; }
}
