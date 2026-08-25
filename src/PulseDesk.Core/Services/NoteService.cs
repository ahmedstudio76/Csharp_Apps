using PulseDesk.Core.Models;

namespace PulseDesk.Core.Services;

public sealed class NoteService
{
    private readonly List<NoteItem> _notes =
    [
        new()
        {
            Title = "Today",
            Body = "Focus on the dashboard polish. Keep the UI quiet — let the data breathe."
        }
    ];

    public IReadOnlyList<NoteItem> GetAll() =>
        _notes.OrderByDescending(n => n.UpdatedUtc).ToList();

    public NoteItem? Get(Guid id) => _notes.FirstOrDefault(n => n.Id == id);

    public NoteItem Add(string title)
    {
        var note = new NoteItem { Title = string.IsNullOrWhiteSpace(title) ? "Untitled" : title.Trim() };
        _notes.Add(note);
        return note;
    }

    public void Update(Guid id, string title, string body)
    {
        var note = Get(id);
        if (note is null)
            return;

        note.Title = string.IsNullOrWhiteSpace(title) ? "Untitled" : title.Trim();
        note.Body = body;
        note.UpdatedUtc = DateTime.UtcNow;
    }

    public void Remove(Guid id) => _notes.RemoveAll(n => n.Id == id);
}
