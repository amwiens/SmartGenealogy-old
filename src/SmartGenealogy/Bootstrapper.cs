using Autofac;

using SmartGenealogy.Contracts.ViewModels;
using SmartGenealogy.Extensions;
using SmartGenealogy.ViewModels;

namespace SmartGenealogy;

public static class Bootstrapper
{
    public static void Register()
    {
        var builder = new ContainerBuilder();

        // Instances


        // Services


        // View Models
        builder.RegisterType<HomeViewModel>().As<IHomeViewModel>().PropertiesAutowired().SingleInstance();
        builder.RegisterType<FilesViewModel>().As<IFileViewModel>().PropertiesAutowired().SingleInstance();
        builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>().SingleInstance();

        var container = builder.Build();
        DependencyInjectionExtension.Resolver = type => container.Resolve(type!);

    }
}