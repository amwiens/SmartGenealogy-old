namespace SmartGenealogy.Maui.Pages;

public static class PagesExtensions
{
    public static MauiAppBuilder ConfigurePages(this MauiAppBuilder builder)
    {
        // main tabs of the app
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<FilePage>();
        builder.Services.AddSingleton<PeoplePage>();
        builder.Services.AddSingleton<PlacesPage>();
        builder.Services.AddSingleton<SourcesPage>();
        builder.Services.AddSingleton<MediaPage>();
        builder.Services.AddSingleton<TasksPage>();
        builder.Services.AddSingleton<AddressesPage>();
        builder.Services.AddSingleton<SearchPage>();
        builder.Services.AddSingleton<PublishPage>();
        builder.Services.AddSingleton<ToolsPage>();
        builder.Services.AddSingleton<SettingsPage>();

        // pages that are navigated to
        builder.Services.AddTransient<PersonPage>();

        return builder;
    }
}