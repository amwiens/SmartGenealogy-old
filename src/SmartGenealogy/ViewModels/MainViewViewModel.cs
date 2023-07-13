using Avalonia.Collections;
using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

using FluentAvalonia.UI.Controls;

using SmartGenealogy.Messages;
using SmartGenealogy.Models;
using SmartGenealogy.Services;

using System.Collections.ObjectModel;

namespace SmartGenealogy.ViewModels;

public partial class MainViewViewModel : ObservableRecipient, IRecipient<OpenFileChangedMessage>
{
    private AppSettings.AppSettings _appSettings => AppSettings.AppSettings.Instance;

    [ObservableProperty]
    private Control _currentPage;

    [ObservableProperty]
    private NavigationItem _selectedNavigationItem;

    partial void OnSelectedNavigationItemChanged(NavigationItem? oldValue, NavigationItem newValue)
    {
        SetCurrentPage();
    }

    [ObservableProperty]
    private ObservableCollection<NavigationItem> _navigationItems = new ObservableCollection<NavigationItem>();

    [ObservableProperty]
    private ObservableCollection<NavigationItem> _footerItems = new ObservableCollection<NavigationItem>();

    public MainViewViewModel()
    {
        NavigationFactory = new NavigationFactory(this);

        WeakReferenceMessenger.Default.Register<OpenFileChangedMessage>(this);
        SetupNavigation();
        SelectedNavigationItem = NavigationItems[0];
    }

    public NavigationFactory NavigationFactory { get; }

    public AvaloniaList<MainAppSearchItem> SearchTerms { get; } = new AvaloniaList<MainAppSearchItem>();

    private void SetupNavigation()
    {
        NavigationItems.Clear();

        NavigationItems.Add(new NavigationItem { Name = "Home", Icon = Symbol.Home, ToolTip = "Dashboard" });
        NavigationItems.Add(new NavigationItem { Name = "File", Icon = Symbol.Document, ToolTip = "File" });

        if (!string.IsNullOrEmpty(_appSettings.FilePath))
        {
            NavigationItems.Add(new NavigationItem { Name = "People", Icon = Symbol.People, ToolTip = "People" });
            NavigationItems.Add(new NavigationItem { Name = "Places", Icon = Symbol.Earth, ToolTip = "Places" });
            NavigationItems.Add(new NavigationItem { Name = "Sources", Icon = Symbol.Library, ToolTip = "Sources" });
            NavigationItems.Add(new NavigationItem { Name = "Media", Icon = Symbol.Image, ToolTip = "Media" });
            NavigationItems.Add(new NavigationItem { Name = "Tasks", Icon = Symbol.ShowResults, ToolTip = "Tasks" });
            NavigationItems.Add(new NavigationItem { Name = "Addresses", Icon = Symbol.ContactInfo, ToolTip = "Addresses" });
            NavigationItems.Add(new NavigationItem { Name = "Search", Icon = Symbol.Find, ToolTip = "Search" });
            NavigationItems.Add(new NavigationItem { Name = "Publish", Icon = Symbol.Print, ToolTip = "Publish" });
            NavigationItems.Add(new NavigationItem { Name = "Tools", Icon = Symbol.Repair, ToolTip = "Tools" });
        }

        FooterItems.Clear();
        FooterItems.Add(new NavigationItem { Name = "Settings", Icon = Symbol.Settings, ToolTip = "Settings" });
    }

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

    public void Receive(OpenFileChangedMessage message)
    {
        SetupNavigation();
    }
}