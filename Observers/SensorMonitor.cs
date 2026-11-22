
using LabW11.Models;
using LabW11.Sensors;

namespace LabW11.Observers;

public sealed class SensorMonitor
{
    private readonly List<IAlertObserver> observers = new();

    // Dang ky observer
    public void Attach(IAlertObserver observer)
    {
        ArgumentNullException.ThrowIfNull(observer);

        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    // Huy dang ky observer
    public void Detach(IAlertObserver observer)
    {
        observers.Remove(observer);
    }

    // Kiem tra cam bien
    public void CheckSensor(string sensorName, ISensor sensor)
    {
        ArgumentNullException.ThrowIfNull(sensor);

        double value = sensor.ReadValue();

        string? severity = value switch
        {
            >= 70 => "CRITICAL",
            >= 50 => "WARNING",
            _ => null
        };

        // Khong co canh bao
        if (severity is null)
        {
            Console.WriteLine(
                $"[NORMAL] {sensorName}: {value:F1}%"
            );
            return;
        }

        // Tao su kien canh bao
        var alertEvent = new AlertEvent(
            sensorName,
            value,
            sensor.GetUnit(),
            severity,
            DateTime.Now
        );

        Notify(alertEvent);
    }

    // Thong bao tat ca observer
    private void Notify(AlertEvent alertEvent)
    {
        foreach (IAlertObserver observer in observers.ToArray())
        {
            try
            {
                observer.Update(alertEvent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"[OBSERVER ERROR] {ex.Message}"
                );
            }
        }
    }
}
