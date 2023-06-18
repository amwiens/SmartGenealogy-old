namespace SmartGenealogy;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

#if WINDOWS || MACCATALYST
        MainPage = new DesktopShell();
#else
        MainPage = new MobileShell();
#endif
    }
}