
using LabW11.Models;

namespace LabW11.Observers;

public interface IAlertObserver
{
    void Update(AlertEvent alertEvent);
}
