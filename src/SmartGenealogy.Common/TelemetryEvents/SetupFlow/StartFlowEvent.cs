using Microsoft.Diagnostics.Telemetry;
using Microsoft.Diagnostics.Telemetry.Internal;

using SmartGenealogy.Telemetry;

using System;
using System.Diagnostics.Tracing;

namespace SmartGenealogy.Common.TelemetryEvents.SetupFlow;

[EventData]
public class StartFlowEvent : EventBase
{
    public string FlowTitle
    {
        get;
    }

    public override PartA_PrivTags PartA_PrivTags => PrivTags.ProductAndServiceUsage;

    public StartFlowEvent(string flowTitle)
    {
        FlowTitle = flowTitle;
    }

    public override void ReplaceSensitiveStrings(Func<string, string> replaceSensitiveStrings)
    {
        // No sensitive strings to replace.
    }
}