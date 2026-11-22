
using LabW11.Models;

namespace LabW11.Emergency;

public interface IEmergencyMediator
{
    void HandleEmergency(AlertEvent alertEvent);
}
