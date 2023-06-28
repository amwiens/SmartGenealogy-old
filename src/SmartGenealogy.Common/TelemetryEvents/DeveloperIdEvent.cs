using Microsoft.Diagnostics.Telemetry;
using Microsoft.Diagnostics.Telemetry.Internal;

using SmartGenealogy.Telemetry;

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace SmartGenealogy.Common.TelemetryEvents;

[EventData]
public class DeveloperIdEvent : EventBase
{
    public override PartA_PrivTags PartA_PrivTags => PrivTags.ProductAndServiceUsage;

    public string developerId
    {
        get;
    }

    public DeveloperIdEvent(string providerName, IDeveloperId devId)
    {
        this.developerId = DeveloperIdHelper.GetHashedDeveloperId(providerName, devId);
    }

    public DeveloperIdEvent(string providerName, IEnumerable<IDeveloperId> devIds)
    {
        this.developerId = string.Join(" , ", devIds.Select(devId => DeveloperIdHelper.GetHashedDeveloperId(providerName, devId)));
    }

    public override void ReplaceSensitiveStrings(Func<string, string> replaceSensitiveStrings)
    {
        // The only sensitive strings is the developerID. GetHashedDeveloperId is used to hash the developerId.
    }
}