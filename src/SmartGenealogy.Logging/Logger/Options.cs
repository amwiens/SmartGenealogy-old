namespace SmartGenealogy.Logging;

public partial class Options : ICloneable
{
    public FailFastSeverityLevel FailFastSeverity { get; set; } = FailFastSeverityLevel.Critical;

    public object Clone() => MemberwiseClone();
}