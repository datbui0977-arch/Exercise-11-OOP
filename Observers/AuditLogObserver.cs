
using LabW11.Models;

namespace LabW11.Observers;

public sealed class AuditLogObserver : IAlertObserver
{
    public void Update(AlertEvent alertEvent)
    {
        Console.WriteLine(
            $"[AUDIT LOG] Time: {alertEvent.OccurredAt} | " +
            $"Sensor: {alertEvent.SensorName} | " +
            $"Value: {alertEvent.Value:F1} | " +
            $"Severity: {alertEvent.Severity}"
        );
    }
}
