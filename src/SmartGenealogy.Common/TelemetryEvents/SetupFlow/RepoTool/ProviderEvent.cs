using Microsoft.Diagnostics.Telemetry;
using Microsoft.Diagnostics.Telemetry.Internal;

using SmartGenealogy.Telemetry;

using System;
using System.Diagnostics.Tracing;

namespace SmartGenealogy.Common.TelemetryEvents.SetupFlow;

[EventData]
public class ProviderEvent : EventBase
{
    public override PartA_PrivTags PartA_PrivTags => PrivTags.ProductAndServiceUsage;

    public int NumberOfProviders
    {
        get;
    }

    public ProviderEvent(int numberOfProviders)
    {
        NumberOfProviders = numberOfProviders;
    }

    public override void ReplaceSensitiveStrings(Func<string, string> replaceSensitiveStrings)
    {
        // No sensitive strings to replace.
    }
}