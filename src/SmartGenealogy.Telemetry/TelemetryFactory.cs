namespace SmartGenealogy.Telemetry;

/// <summary>
/// Creates instance of Telemetry
/// This would be useful for the future when interfaces have been updated for logger like ITelemetry2, ITelemetry3 and so on
/// </summary>
public class TelemetryFactory
{
    private static readonly object LockObj = new();

    private static Telemetry telemetryInstance;

    private static Telemetry GetTelemetryInstance()
    {
        if (telemetryInstance == null)
        {
            lock (LockObj)
            {
                telemetryInstance ??= new Telemetry();
                telemetryInstance.AddWellKnownSensitiveStrings();
            }
        }

        return telemetryInstance;
    }

    public static T Get<T>()
        where T : ITelemetry
    {
        return (T)(object)GetTelemetryInstance();
    }
}