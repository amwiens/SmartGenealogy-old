using Avalonia.Controls;

using FluentAvalonia.UI.Controls;

using SmartGenealogy.Pages;
using SmartGenealogy.ViewModels;
using SmartGenealogy.Views;

namespace SmartGenealogy.Services;

public class NavigationFactory : INavigationPageFactory
{
    public NavigationFactory(MainViewViewModel owner)
    {
        Owner = owner;
    }

    public MainViewViewModel Owner { get; }

    public Control GetPage(Type srcType)
    {
        return null;
    }

    public Control GetPageFromObject(object target)
    {
        if (target is HomePageViewModel)
        {
            return new HomePage
            {
                DataContext = target
            };
        }
        else if (target is FilePageViewModel)
        {
            return new FilePage
            {
                DataContext = target
            };
        }
        else if (target is PeoplePageViewModel)
        {
            return new PeoplePage
            {
                DataContext = target
            };
        }
        else if (target is PlacesPageViewModel)
        {
            return new PlacesPage
            {
                DataContext = target
            };
        }
        else if (target is SourcesPageViewModel)
        {
            return new SourcesPage
            {
                DataContext = target
            };
        }
        else if (target is MediaPageViewModel)
        {
            return new MediaPage
            {
                DataContext = target
            };
        }
        else if (target is TasksPageViewModel)
        {
            return new TasksPage
            {
                DataContext = target
            };
        }
        else if (target is AddressesPageViewModel)
        {
            return new AddressesPage
            {
                DataContext = target
            };
        }
        else if (target is SearchPageViewModel)
        {
            return new SearchPage
            {
                DataContext = target
            };
        }
        else if (target is PublishPageViewModel)
        {
            return new PublishPage
            {
                DataContext = target
            };
        }
        else if (target is ToolsPageViewModel)
        {
            return new ToolsPage
            {
                DataContext = target
            };
        }
        else if (target is SettingsPageViewModel)
        {
            return new SettingsPage
            {
                DataContext = target
            };
        }

        return null;
    }

    //private Control ResolvePage(PageBaseViewModel pbvm)
    //{
    //    if (pbvm is null)
    //        return null;

    //    Control page = null;
    //    var key = pbvm.PageKey;

    //    if (CorePages.TryGetValue(key, out var func))
    //    {
    //        page = func();

    //        const string faPageGithub =
    //            "https://github.com/amwx/FluentAvalonia/tree/master/samples/FAControlsGallery/Pages/CoreControlPages";

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