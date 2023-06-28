using Microsoft.Diagnostics.Telemetry;
using Microsoft.Diagnostics.Telemetry.Internal;

using SmartGenealogy.Telemetry;

using System;
using System.Diagnostics.Tracing;

namespace SmartGenealogy.Common.TelemetryEvents.SetupFlow;

[EventData]
public class RepoDialogGetAccountEvent : EventBase
{
    public override PartA_PrivTags PartA_PrivTags => PrivTags.ProductAndServiceUsage;

    public string ProviderName
    {
        get;
    }

    public bool AlreadyLoggedIn
    {
        get;
    }

    public RepoDialogGetAccountEvent(string providerName, bool alreadyLogggedIn)
    {
        ProviderName = providerName;
        AlreadyLoggedIn = alreadyLogggedIn;
    }

    public override void ReplaceSensitiveStrings(Func<string, string> replaceSensitiveStrings)
    {
        // No sensitive strings to replace.
    }
}