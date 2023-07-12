using Avalonia.Collections;
using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using FluentAvalonia.UI.Controls;

using SmartGenealogy.Models;
using SmartGenealogy.Services;

namespace SmartGenealogy.ViewModels;

public partial class MainViewViewModel : ViewModelBase
{
    [ObservableProperty]
    private Control _currentPage;

    [ObservableProperty]
    private NavigationItem _selectedNavigationItem;

    partial void OnSelectedNavigationItemChanged(NavigationItem? oldValue, NavigationItem newValue)
    {
        SetCurrentPage();
    }

    [ObservableProperty]
    private List<NavigationItem> _navigationItems = new List<NavigationItem>();

    [ObservableProperty]
    private List<NavigationItem> _footerItems = new List<NavigationItem>();

    public MainViewViewModel()
    {
        NavigationFactory = new NavigationFactory(this);

        NavigationItems.Add(new NavigationItem { Name = "Home", Icon = Symbol.Home, ToolTip = "Dashboard" });
        NavigationItems.Add(new NavigationItem { Name = "File", Icon = Symbol.Document, ToolTip = "File" });
        NavigationItems.Add(new NavigationItem { Name = "People", Icon = Symbol.People, ToolTip = "People" });
        NavigationItems.Add(new NavigationItem { Name = "Places", Icon = Symbol.Earth, ToolTip = "Places" });
        NavigationItems.Add(new NavigationItem { Name = "Sources", Icon = Symbol.Library, ToolTip = "Sources" });
        NavigationItems.Add(new NavigationItem { Name = "Media", Icon = Symbol.Image, ToolTip = "Media" });
        NavigationItems.Add(new NavigationItem { Name = "Tasks", Icon = Symbol.ShowResults, ToolTip = "Tasks" });
        NavigationItems.Add(new NavigationItem { Name = "Addresses", Icon = Symbol.ContactInfo, ToolTip = "Addresses" });
        NavigationItems.Add(new NavigationItem { Name = "Search", Icon = Symbol.Find, ToolTip = "Search" });
        NavigationItems.Add(new NavigationItem { Name = "Publish", Icon = Symbol.Print, ToolTip = "Publish" });
        NavigationItems.Add(new NavigationItem { Name = "Tools", Icon = Symbol.Repair, ToolTip = "Tools" });

        FooterItems.Add(new NavigationItem { Name = "Settings", Icon = Symbol.Settings, ToolTip = "Settings" });

        SelectedNavigationItem = NavigationItems[0];
    }

    public NavigationFactory NavigationFactory { get; }

    public AvaloniaList<MainAppSearchItem> SearchTerms { get; } = new AvaloniaList<MainAppSearchItem>();

    public void BuildSearchTerms(MainPageViewModelBase pageItem)
    {
    }

    private void SetCurrentPage()
    {
        if (SelectedNavigationItem is NavigationItem cat)
        {
            var smpPage = $"SmartGenealogy.Pages.{SelectedNavigationItem.Name}Page";
            var pg = Activator.CreateInstance(Type.GetType(smpPage));
            CurrentPage = (Control)pg;
        }
        //else if (SelectedCategory is NavigationViewItem nvi)
        //{
        //}
    }
}