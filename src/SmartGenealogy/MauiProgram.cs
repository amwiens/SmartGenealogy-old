using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
                fonts.AddFont("icon.ttf", "SmartGenealogyIcons");
            })
            .RegisterAppServices()
            .RegisterViewModels()
            .GetAppSettings();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
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
        builder.Services.AddTransient<PeoplePage>();
        builder.Services.AddTransient<PlacesPage>();
        builder.Services.AddTransient<SourcesPage>();
        builder.Services.AddTransient<MediaPage>();
        builder.Services.AddTransient<TasksPage>();
        builder.Services.AddTransient<AddressesPage>();
        builder.Services.AddTransient<SearchPage>();
        builder.Services.AddTransient<PublishPage>();
        builder.Services.AddTransient<ToolsPage>();
        builder.Services.AddTransient<ChatDetailPage>();
        builder.Services.AddTransient<SettingsPage>();

        builder.Services.AddTransient<HomePageViewModel>();
        builder.Services.AddTransient<MainMenuViewModel>();
        builder.Services.AddTransient<PeoplePageViewModel>();
        builder.Services.AddTransient<PlacesPageViewModel>();
        builder.Services.AddTransient<SourcesPageViewModel>();
        builder.Services.AddTransient<MediaPageViewModel>();
        builder.Services.AddTransient<TasksPageViewModel>();
        builder.Services.AddTransient<AddressesPageViewModel>();
        builder.Services.AddTransient<SearchPageViewModel>();
        builder.Services.AddTransient<PublishPageViewModel>();
        builder.Services.AddTransient<ToolsPageViewModel>();
        builder.Services.AddTransient<ChatDetailPageViewModel>();
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