
namespace LabW11.Sensors;

public sealed class LegacySmokeDetector
{
    private int smokeLevel;

    public LegacySmokeDetector(int smokeLevel)
    {
        this.smokeLevel = Math.Clamp(smokeLevel, 0, 1000);
    }

    public int GetSmokeLevel()
    {
        return smokeLevel;
    }

    public string GetDescription()
    {
        return "Legacy smoke detector";
    }

    public void SetSmokeLevel(int value)
    {
        smokeLevel = Math.Clamp(value, 0, 1000);
    }
}
