namespace SmartGenealogy.Logging.Listeners;

public interface IListener
{
    string Name
    {
        get;
    }

    ILoggerHost? Host
    {
        get;
        set;
    }

    void HandleLogEvent(LogEvent evt);
}