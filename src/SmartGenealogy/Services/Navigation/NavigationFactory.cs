using Avalonia.Controls;

using FluentAvalonia.UI.Controls;

using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Services;

public class NavigationFactory : INavigationPageFactory
{
    public NavigationFactory(MainWindowViewModel owner)
    {
        Owner = owner;
    }

    public MainWindowViewModel Owner { get; }

    public Control GetPage(Type srcType)
    {
        return null;
    }

    public Control GetPageFromObject(object target)
    {
        //if (target is HomeViewModel)
        //{
        //    return new Home
        //    {
        //        DataContext = target
        //    };
        //}
        //else if (target is FilesViewModel)
        //{
        //    return new Files
        //    {
        //        DataContext = target
        //    };
        //}
        //else if (target is PeoplePageViewModel)
        //{
        //    return new People
        //    {
        //        DataContext = target
        //    };
        //}
        //else if (target is PlacesPageViewModel)
        //{
        //    return new Places
        //    {
        //        DataContext = target
        //    };
        //}
        //else if (target is SourcesPageViewModel)
        //{
        //    return new Sources
        //    {
        //        DataContext = target
        //    };
        //}
        //else if (target is MediaPageViewModel)
        //{
        //    return new Media
        //    {
        //        DataContext = target
        //    };
        //}
        //else if (target is TasksPageViewModel)
        //{
        //    return new Tasks
        //    {
        //        DataContext = target
        //    };
        //}
        //else if (target is AddressesPageViewModel)
        //{
        //    return new Addresses
        //    {
        //        DataContext = target
        //    };
        //}
        //else if (target is SearchPageViewModel)
        //{
        //    return new Search
        //    {
        //        DataContext = target
        //    };
        //}
        //else if (target is PublishPageViewModel)
        //{
        //    return new Publish
        //    {
        //        DataContext = target
        //    };
        //}
        //else if (target is ToolsPageViewModel)
        //{
        //    return new Tools
        //    {
        //        DataContext = target
        //    };
        //}
        //else if (target is SettingsPageViewModel)
        //{
        //    return new Settings
        //    {
        //        DataContext = target
        //    };
        //}

        return null;
    }

    //private Control ResolvePage(PageBaseViewModel pbvm)
    //{
    //    if (pbvm is null)
    //        return null;

    // Control page = null; var key = pbvm.PageKey;

    // if (CorePages.TryGetValue(key, out var func)) { page = func();

    // const string faPageGithub = "https://github.com/amwx/FluentAvalonia/tree/master/samples/FAControlsGallery/Pages/CoreControlPages";

    //        (page as ControlsPageBase).GithubPrefixString = faPageGithub;
    //        (page as ControlsPageBase).CreationContext = pbvm;
    //    }
    //    else if (FaPages.TryGetValue(key, out func))
    //    {
    //        var pg = (ControlsPageBase)func();
    //        var dc = ()
    //    }
    //}
}