namespace SmartGenealogy.Maui;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        TheTheme.SetTheme();

        if (Config.Desktop)
            MainPage = new DesktopShell();
        else
            MainPage = new MobileShell();

        Routing.RegisterRoute(nameof(PersonPage), typeof(PersonPage));
    }

    Window window;
    protected override Window CreateWindow(IActivationState activationState)
    {
        window = base.CreateWindow(activationState);
        if (DeviceInfo.Platform == DevicePlatform.WinUI ||
            DeviceInfo.Platform == DevicePlatform.MacCatalyst)
        {
            window.MinimumWidth = 1080;
            window.MinimumHeight = 500;

            window.SizeChanged += Window_SizeChanged;
        }

        return window;
    }

    private void Window_SizeChanged(object sender, EventArgs e)
    {
        if (window is null)
            return;

        if (window.Width < 1200)
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        else
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Locked;
    }
}