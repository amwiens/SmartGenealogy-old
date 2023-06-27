namespace SmartGenealogy.Logging;

public class GlobalLog
{
    public static Logger? Logger { get; } = new ComponentLogger("SmartGenealogy").Logger;
}