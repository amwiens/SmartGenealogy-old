using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SmartGenealogy.Maui.Navigation;

using System.Reflection;

namespace SmartGenealogy;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitCore()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .RegisterServices()
            .RegisterAppServices()
            .RegisterViewModels()
            .GetAppSettings();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }



    static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IFilePicker, FilePicker>();
        builder.Services.AddSingleton<IAppNavigator, AppNavigator>();

        return builder;
    }

    static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<DesktopShell>();
        builder.Services.AddSingleton<MobileShell>();

        return builder;
    }


    static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<SettingsPage>();

        builder.Services.AddTransient<HomePageViewModel>();
        builder.Services.AddTransient<SettingsPageViewModel>();


        return builder;
    }

    static MauiAppBuilder GetAppSettings(this MauiAppBuilder builder)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("SmartGenealogy.appsettings.Development.json");

        var appSettings = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();

        builder.Configuration.AddConfiguration(appSettings);

        return builder;
    }
}