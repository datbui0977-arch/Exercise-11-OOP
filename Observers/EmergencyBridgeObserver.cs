
using LabW11.Models;
using LabW11.Emergency;

namespace LabW11.Observers;

public sealed class EmergencyBridgeObserver : IAlertObserver
{
    private readonly IEmergencyMediator mediator;

    public EmergencyBridgeObserver(
        IEmergencyMediator mediator)
    {
        this.mediator = mediator ??
            throw new ArgumentNullException(nameof(mediator));
    }

    public void Update(AlertEvent alertEvent)
    {
        if (alertEvent.Severity == "CRITICAL")
        {
            Console.WriteLine(
                "[EMERGENCY BRIDGE] Critical alert detected!"
            );

            mediator.HandleEmergency(alertEvent);
        }
    }
}
