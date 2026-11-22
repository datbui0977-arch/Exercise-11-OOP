
using LabW11.Models;

namespace LabW11.Observers;

public sealed class EmailAlertObserver : IAlertObserver
{
    public void Update(AlertEvent alertEvent)
    {
        Console.WriteLine(
            $"[EMAIL] Sending notification: " +
            $"{alertEvent.SensorName} - " +
            $"{alertEvent.Severity}"
        );
    }
}
