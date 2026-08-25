using PulseDesk.Core.Models;

namespace PulseDesk.Core.Services;

public sealed class TaskBoardService
{
    private readonly List<TaskItem> _tasks =
    [
        new() { Title = "Ship PulseDesk dashboard", Priority = TaskPriority.High },
        new() { Title = "Polish glassmorphism cards", Priority = TaskPriority.Medium },
        new() { Title = "Write README for the monorepo", Priority = TaskPriority.Low, IsDone = true }
    ];

    public IReadOnlyList<TaskItem> GetAll() => _tasks
        .OrderBy(t => t.IsDone)
        .ThenByDescending(t => t.Priority)
        .ThenBy(t => t.CreatedUtc)
        .ToList();

    public void Add(string title, TaskPriority priority)
    {
        var trimmed = title.Trim();
        if (string.IsNullOrWhiteSpace(trimmed))
            return;

        _tasks.Add(new TaskItem { Title = trimmed, Priority = priority });
    }

    public void Toggle(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task is not null)
            task.IsDone = !task.IsDone;
    }

    public void Remove(Guid id) => _tasks.RemoveAll(t => t.Id == id);

    public int OpenCount => _tasks.Count(t => !t.IsDone);
    public int DoneCount => _tasks.Count(t => t.IsDone);
}
