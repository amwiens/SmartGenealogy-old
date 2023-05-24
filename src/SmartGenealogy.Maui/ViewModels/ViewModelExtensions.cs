namespace SmartGenealogy.Maui.ViewModels;

public static class ViewModelExtensions
{
    public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<AddressesViewModel>();
        builder.Services.AddSingleton<FileViewModel>();
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<MediaViewModel>();
        builder.Services.AddSingleton<PeopleViewModel>();
        builder.Services.AddSingleton<PersonViewModel>();
        builder.Services.AddSingleton<PlacesViewModel>();
        builder.Services.AddSingleton<PublishViewModel>();
        builder.Services.AddSingleton<SearchViewModel>();
        builder.Services.AddSingleton<SettingsViewModel>();
        builder.Services.AddSingleton<ShellViewModel>();
        builder.Services.AddSingleton<SourcesViewModel>();
        builder.Services.AddSingleton<TasksViewModel>();
        builder.Services.AddSingleton<ToolsViewModel>();

        return builder;
    }
}