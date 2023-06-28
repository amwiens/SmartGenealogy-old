using AdaptiveCards.ObjectModel.WinUI3;
using AdaptiveCards.Templating;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using SmartGenealogy.Logging;

using System;
using System.Text.Json.Nodes;

namespace SmartGenealogy.Common.Models;

public class PluginAdaptiveCard : IPluginAdaptiveCard
{
    public event EventHandler<AdaptiveCard>? UiUpdate;

    public string DataJson { get; private set; }

    public string State { get; private set; }

    public string TemplateJson { get; private set; }

    public PluginAdaptiveCard()
    {
        TemplateJson = new JsonObject().ToJsonString();
        DataJson = new JsonObject().ToJsonString();
        State = string.Empty;
    }

    public void Update(string templateJson, string dataJson, string state)
    {
        var template = new AdaptiveCardTemplate(templateJson ?? TemplateJson);
        var adaptiveCardString = template.Expand(JsonConvert.DeserializeObject<JObject>(dataJson ?? DataJson));
        var parseResult = AdaptiveCard.FromJsonString(adaptiveCardString);

        if (parseResult.AdaptiveCard is null)
        {
            GlobalLog.Logger?.ReportError($"PluginAdaptiveCard.Update(): AdaptiveCard is null - templateJson: {templateJson} dataJson: {dataJson} state: {state}");
            return;
        }

        TemplateJson = templateJson ?? TemplateJson;
        DataJson = dataJson ?? DataJson;
        State = state ?? State;

        if (UiUpdate is not null)
        {
            UiUpdate.Invoke(this, parseResult.AdaptiveCard);
        }
    }
}