﻿using SmartGenealogy.Logging.Listeners;

namespace SmartGenealogy.Logging;

public interface ILoggerHost : IDisposable
{
    string Name
    {
        get;
    }

    Options Options
    {
        get;
    }

    Dictionary<string, IListener> Listeners
    {
        get;
    }

    void AddListener(IListener listener);

    void ReportEvent(LogEvent evt);

    void ReportEvent(string component, SeverityLevel severity, string message);

    void ReportEvent(string component, SeverityLevel severity, string message, Exception exception);

    void ReportEvent(string component, string subComponent, SeverityLevel severity, string message);

    void ReportEvent(string component, string subComponent, SeverityLevel severity, string message, Exception exception);

    void ReportDebug(string component, string message);

    void ReportDebug(string component, string message, Exception exception);

    void ReportDebug(string component, string subComponent, string message);

    void ReportDebug(string component, string subComponent, string message, Exception exception);

    void ReportInfo(string component, string message);

    void ReportInfo(string component, string message, Exception exception);

    void ReportInfo(string component, string subComponent, string message);

    void ReportInfo(string component, string subComponent, string message, Exception exception);

    void ReportWarn(string component, string message);

    void ReportWarn(string component, string message, Exception exception);

    void ReportWarn(string component, string subComponent, string message);

    void ReportWarn(string component, string subComponent, string message, Exception exception);

    void ReportError(string component, string message);

    void ReportError(string component, string message, Exception exception);

    void ReportError(string component, string subComponent, string message);

    void ReportError(string component, string subComponent, string message, Exception exception);

    void ReportCritical(string component, string message);

    void ReportCritical(string component, string message, Exception exception);

    void ReportCritical(string component, string subComponent, string message);

    void ReportCritical(string component, string subComponent, string message, Exception exception);
}