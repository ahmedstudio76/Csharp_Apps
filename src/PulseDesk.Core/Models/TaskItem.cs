namespace PulseDesk.Core.Models;

public enum TaskPriority
{
    Low,
    Medium,
    High
}

public sealed class TaskItem
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public bool IsDone { get; set; }
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;
    public DateTime CreatedUtc { get; init; } = DateTime.UtcNow;
}
