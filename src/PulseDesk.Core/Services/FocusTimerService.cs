namespace PulseDesk.Core.Services;

public sealed class FocusTimerService
{
    public TimeSpan Duration { get; private set; } = TimeSpan.FromMinutes(25);
    public TimeSpan Remaining { get; private set; } = TimeSpan.FromMinutes(25);
    public bool IsRunning { get; private set; }
    public int CompletedSessions { get; private set; }

    public void Tick(TimeSpan delta)
    {
        if (!IsRunning)
            return;

        Remaining -= delta;
        if (Remaining <= TimeSpan.Zero)
        {
            Remaining = TimeSpan.Zero;
            IsRunning = false;
            CompletedSessions++;
        }
    }

    public void Start() => IsRunning = Remaining > TimeSpan.Zero;
    public void Pause() => IsRunning = false;

    public void Reset(int minutes = 25)
    {
        IsRunning = false;
        Duration = TimeSpan.FromMinutes(minutes);
        Remaining = Duration;
    }

    public double Progress => Duration.TotalSeconds <= 0
        ? 0
        : 1 - Remaining.TotalSeconds / Duration.TotalSeconds;
}
