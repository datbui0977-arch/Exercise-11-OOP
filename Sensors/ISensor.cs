namespace LabW11.Sensors;

public interface ISensor
{
    double ReadValue();

    string GetUnit();
}
