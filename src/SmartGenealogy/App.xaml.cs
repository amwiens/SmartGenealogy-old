using Microsoft.UI.Xaml;

using SmartGenealogy.Helpers;

using Windows.ApplicationModel.Activation;

namespace SmartGenealogy;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    private static Window startupWindow;

    /// <summary>
    /// Get the initial window created for this app
    /// On UWP, this is simply Window.Current
    /// On Desktop, multiple Windows may be created, and the StartupWindow may have already
    /// been closed.
    /// </summary>
    public static Window StartupWindow
    {
        get
        {
            return startupWindow;
        }
    }

    /// <summary>
    /// Initializes the singleton Application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {

    }

    /// <summary>
    /// Invoked when the application is launched normally by the end user. Other entry points
    /// will be used such as when the application is launched to open a specific file.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override async void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {


        startupWindow = WindowHelper.CreateWindow();
        startupWindow.ExtendsContentIntoTitleBar = true;



        EnsureWindow();
    }

    private async void EnsureWindow(IActivatedEventArgs args = null)
    {

    }
}