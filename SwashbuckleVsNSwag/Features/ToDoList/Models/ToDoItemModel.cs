namespace SwashbuckleVsNSwag.Features.ToDoList.Models;

public class ToDoItemModel
{
    public int Id { get; init; }
    
    public required string Title { get; set; }

    public bool? Done { get; set; }

    public DateTimeOffset DueDateTime { get; set; }
}
