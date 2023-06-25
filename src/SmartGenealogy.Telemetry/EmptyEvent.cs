using Microsoft.Diagnostics.Telemetry;
using Microsoft.Diagnostics.Telemetry.Internal;

using System;
using System.Diagnostics.Tracing;

namespace SmartGenealogy.Telemetry;

[EventData]
public class EmptyEvent : EventBase
{
    public override PartA_PrivTags PartA_PrivTags => PrivTags.ProductAndServiceUsage;

    public override void ReplaceSensitiveStrings(Func<string, string> replaceSensitiveStrings)
    {
        // No sensitive string
    }
}