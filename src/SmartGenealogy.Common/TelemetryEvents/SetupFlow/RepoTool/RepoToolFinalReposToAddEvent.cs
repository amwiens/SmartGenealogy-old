using Microsoft.Diagnostics.Telemetry;
using Microsoft.Diagnostics.Telemetry.Internal;

using SmartGenealogy.Telemetry;

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace SmartGenealogy.Common.TelemetryEvents.SetupFlow;

[EventData]
public class FinalRepoResult
{ 
    public string ProviderName { get; }

    public AddKind AddKind { get; }

    public CloneLocationKind CloneLocationKind { get; }

    public FinalRepoResult(string providerName, AddKind addKind, CloneLocationKind cloneLocationKind)
    {
        ProviderName = providerName;
        AddKind = addKind;
        CloneLocationKind = cloneLocationKind;
    }
}

[EventData]
public class RepoToolFinalReposToAddEvent : EventBase
{
    public override PartA_PrivTags PartA_PrivTags => PrivTags.ProductAndServiceUsage;

    public List<FinalRepoResult> FinalAddedRepos { get; }

    public RepoToolFinalReposToAddEvent(List<FinalRepoResult> addedRepos)
    {
        FinalAddedRepos = new List<FinalRepoResult>();
        FinalAddedRepos.AddRange(addedRepos);
    }

    public override void ReplaceSensitiveStrings(Func<string, string> replaceSensitiveStrings)
    {
        // No sensitive strings to replace.
    }
}