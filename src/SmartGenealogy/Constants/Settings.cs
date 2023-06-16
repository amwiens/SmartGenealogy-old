namespace SmartGenealogy.Constants;

internal static class Settings
{
    public static bool IsDesktop
    {
        get
        {
#if WINDOWS || MACCATALYST
            return true;
#else
            return false;
#endif
        }
    }
}