using Microsoft.Diagnostics.Telemetry;
using Microsoft.Diagnostics.Telemetry.Internal;

using SmartGenealogy.Telemetry;

using System;
using System.Diagnostics.Tracing;

namespace SmartGenealogy.Common.TelemetryEvents.SetupFlow;

[EventData]
public class LoadingRetryEvent : EventBase
{
    public int NumberOfFailedTasks { get; }

    public override PartA_PrivTags PartA_PrivTags => PrivTags.ProductAndServiceUsage;

    public LoadingRetryEvent(int numberOfFailedTasks)
    {
        NumberOfFailedTasks = numberOfFailedTasks;
    }

    public override void ReplaceSensitiveStrings(Func<string, string> replaceSensitiveStrings)
    {
        // No sensitive strings to replace.
    }
}