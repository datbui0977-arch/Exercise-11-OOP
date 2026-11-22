
using LabW11.Models;
using LabW11.Devices;

namespace LabW11.Emergency;

public sealed class EmergencyMediator : IEmergencyMediator
{
    private readonly Alarm alarm;
    private readonly DoorController door;
    private readonly VentilationController ventilation;

    public EmergencyMediator(
        Alarm alarm,
        DoorController door,
        VentilationController ventilation)
    {
        this.alarm = alarm;
        this.door = door;
        this.ventilation = ventilation;
    }

    public void HandleEmergency(AlertEvent alertEvent)
    {
        if (alertEvent.Severity != "CRITICAL")
        {
            return;
        }

        Console.WriteLine(
            "\n===== EMERGENCY RESPONSE ====="
        );

        alarm.Activate();

        door.Unlock();

        ventilation.EnableEmergencyMode();

        Console.WriteLine(
            "===== RESPONSE COMPLETED =====\n"
        );
    }
}
