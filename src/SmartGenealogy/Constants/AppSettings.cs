namespace SmartGenealogy.Constants;

internal static class AppSettings
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