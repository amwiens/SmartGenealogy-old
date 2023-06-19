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
                fonts.AddFont("Poppins-Regular.otf", "RegularFont");
                fonts.AddFont("Poppins-Medium.otf", "MediumFont");
                fonts.AddFont("Poppins-SemiBold.otf", "SemiBoldFont");
                fonts.AddFont("Poppins-Bold.otf", "BoldFont");
                fonts.AddFont("Roboto-Bold.ttf", "SecondBoldFontFamily");
                fonts.AddFont("Roboto-Medium.ttf", "SecondMediumFontFamily");
                fonts.AddFont("Roboto-Regular.ttf", "SecondFontFamily");

                fonts.AddFont("fa-solid-900.ttf", "FaPro");
                fonts.AddFont("fa-brands-400.ttf", "FaBrands");
                fonts.AddFont("fa-regular-400.ttf", "FaRegular");
                fonts.AddFont("line-awesome.ttf", "LineAwesome");
                fonts.AddFont("material-icons-outlined-regular.otf", "MaterialDesign");
                fonts.AddFont("ionicons.ttf", "IonIcons");
                fonts.AddFont("icon.ttf", "MauiKitIcons");
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
        builder.Services.AddTransient<MainMenuPage>();
        builder.Services.AddTransient<SettingsPage>();

        builder.Services.AddTransient<HomePageViewModel>();
        builder.Services.AddTransient<MainMenuViewModel>();
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