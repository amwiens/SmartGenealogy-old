namespace SmartGenealogy.Maui.Services;

public static class ServicesExtensions
{
    public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<PeopleService>();
        builder.Services.TryAddTransient<WifiOptionsService>();

        return builder;
    }
}