using Autofac;

using Serilog;

using SmartGenealogy.Contracts;
using SmartGenealogy.Contracts.ViewModels;
using SmartGenealogy.Extensions;
using SmartGenealogy.Services;
using SmartGenealogy.ViewModels;
using SmartGenealogy.ViewModels.Addresses;
using SmartGenealogy.ViewModels.Files;
using SmartGenealogy.ViewModels.Home;
using SmartGenealogy.ViewModels.Media;
using SmartGenealogy.ViewModels.People;
using SmartGenealogy.ViewModels.Places;
using SmartGenealogy.ViewModels.Publish;
using SmartGenealogy.ViewModels.Search;
using SmartGenealogy.ViewModels.Settings;
using SmartGenealogy.ViewModels.Sources;
using SmartGenealogy.ViewModels.Tasks;
using SmartGenealogy.ViewModels.Tools;

namespace SmartGenealogy;

public static class Bootstrapper
{
    public static void Register()
    {
        var builder = new ContainerBuilder();

        // Instances
        builder.RegisterInstance(Log.Logger).As<ILogger>().SingleInstance();

        // Services
        builder.RegisterType<LocalizationService>().As<ILocalizationService>().PropertiesAutowired().SingleInstance(); ;
        builder.RegisterType<SettingService>().As<ISettingService>().PropertiesAutowired().SingleInstance();
        builder.RegisterType<UpdateTextService>().As<IUpdateTextService>().PropertiesAutowired().SingleInstance();

        // View Models
        builder.RegisterType<HomeViewModel>().As<IHomeViewModel>().PropertiesAutowired().SingleInstance();
        builder.RegisterType<FilesViewModel>().As<IFileViewModel>().PropertiesAutowired().SingleInstance();
        builder.RegisterType<PeopleViewModel>().As<IPeopleViewModel>().PropertiesAutowired().SingleInstance();
        builder.RegisterType<PlacesViewModel>().As<IPlacesViewModel>().PropertiesAutowired().SingleInstance();
        builder.RegisterType<SourcesViewModel>().As<ISourcesViewModel>().PropertiesAutowired().SingleInstance();
        builder.RegisterType<MediaViewModel>().As<IMediaViewModel>().PropertiesAutowired().SingleInstance();
        builder.RegisterType<TasksViewModel>().As<ITasksViewModel>().PropertiesAutowired().SingleInstance();
        builder.RegisterType<AddressesViewModel>().As<IAddressesViewModel>().PropertiesAutowired().SingleInstance();
        builder.RegisterType<SearchViewModel>().As<ISearchViewModel>().PropertiesAutowired().SingleInstance();
        builder.RegisterType<PublishViewModel>().As<IPublishViewModel>().PropertiesAutowired().SingleInstance();
        builder.RegisterType<ToolsViewModel>().As<IToolsViewModel>().PropertiesAutowired().SingleInstance();
        builder.RegisterType<SettingsPageViewModel>().As<ISettingsPageViewModel>().PropertiesAutowired().SingleInstance();
        builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>().SingleInstance();

        var container = builder.Build();
        DependencyInjectionExtension.Resolver = type => container.Resolve(type!);
        SettingExtensions.SettingService = container.Resolve<ISettingService>();
        LocalizeExtensions.LocalizationService = container.Resolve<ILocalizationService>();
    }
}