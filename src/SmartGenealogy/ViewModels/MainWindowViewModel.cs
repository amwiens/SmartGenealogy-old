using Avalonia.Collections;
using Avalonia.Markup.Xaml.MarkupExtensions;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using FluentAvalonia.UI.Controls;

using SmartGenealogy.Contracts;
using SmartGenealogy.Contracts.ViewModels;
using SmartGenealogy.Messages;
using SmartGenealogy.Models;

using System.Collections.ObjectModel;
using System.Text.Json;

namespace SmartGenealogy.ViewModels;

public partial class MainWindowViewModel : ObservableRecipient, IMainWindowViewModel, IRecipient<OpenFileChangedMessage>
{
    private readonly ISettingService _settingService;
    //private AppSettings.AppSettings _appSettings => AppSettings.AppSettings.Instance;

    [ObservableProperty]
    private ViewModelBase _currentPage;

    [ObservableProperty]
    private NavigationItem _selectedNavigationItem;

    [ObservableProperty]
    private ObservableCollection<NavigationItem> _navigationItems = new();

    [ObservableProperty]
    private ObservableCollection<NavigationItem> _footerItems = new();

    public MainWindowViewModel(IHomeViewModel homeViewModel,
        IFileViewModel fileViewModel,
        IPeopleViewModel peopleViewModel,
        IPlacesViewModel placesViewModel,
        ISourcesViewModel sourcesViewModel,
        IMediaViewModel mediaViewModel,
        ITasksViewModel tasksViewModel,
        IAddressesViewModel addressesViewModel,
        ISearchViewModel searchViewModel,
        IPublishViewModel publishViewModel,
        IToolsViewModel toolsViewModel,
        ISettingsPageViewModel settingsViewModel,
        ISettingService settingService)
    {
        _settingService = settingService;
        //NavigationFactory = new NavigationFactory(this);

        WeakReferenceMessenger.Default.Register<OpenFileChangedMessage>(this);

        NavigationItems = new ObservableCollection<NavigationItem>
        {
            new((ViewModelBase)homeViewModel, "Home", "Home", Symbol.Home),
            new((ViewModelBase)fileViewModel, "File", "File", Symbol.Document),
            new((ViewModelBase)peopleViewModel, "People", "People", Symbol.People),
            new((ViewModelBase)placesViewModel, "Places", "Places", Symbol.Earth),
            new((ViewModelBase)sourcesViewModel, "Sources", "Sources", Symbol.Library),
            new((ViewModelBase)mediaViewModel, "Media", "Media", Symbol.Image),
            new((ViewModelBase)tasksViewModel, "Tasks", "Tasks", Symbol.ShowResults),
            new((ViewModelBase)addressesViewModel, "Addresses", "Addresses", Symbol.ContactInfo),
            new((ViewModelBase)searchViewModel, "Search", "Search", Symbol.Find),
            new((ViewModelBase)publishViewModel, "Publish", "Publish", Symbol.Print),
            new((ViewModelBase)toolsViewModel, "Tools", "Tools", Symbol.Repair)
        };

        FooterItems = new ObservableCollection<NavigationItem>
        {
            new((ViewModelBase)settingsViewModel, "Settings", "Settings", Symbol.Settings)
        };

        SelectedNavigationItem = NavigationItems[0];
        SwitchTab();
        AppDomain.CurrentDomain.ProcessExit += OnExit!;
    }

    //public NavigationFactory NavigationFactory { get; }

    public AvaloniaList<MainAppSearchItem> SearchTerms { get; } = new AvaloniaList<MainAppSearchItem>();

    private void SetupNavigation()
    {
        //NavigationItems.Clear();

        //NavigationItems.Add(new NavigationItem { Name = "Home", Icon = Symbol.Home, ToolTip = "Dashboard" });
        //NavigationItems.Add(new NavigationItem { Name = "File", Icon = Symbol.Document, ToolTip = "File" });

        //if (!string.IsNullOrEmpty(_appSettings.FilePath))
        //{
        //    NavigationItems.Add(new NavigationItem { Name = "People", Icon = Symbol.People, ToolTip = "People" });
        //    NavigationItems.Add(new NavigationItem { Name = "Places", Icon = Symbol.Earth, ToolTip = "Places" });
        //    NavigationItems.Add(new NavigationItem { Name = "Sources", Icon = Symbol.Library, ToolTip = "Sources" });
        //    NavigationItems.Add(new NavigationItem { Name = "Media", Icon = Symbol.Image, ToolTip = "Media" });
        //    NavigationItems.Add(new NavigationItem { Name = "Tasks", Icon = Symbol.ShowResults, ToolTip = "Tasks" });
        //    NavigationItems.Add(new NavigationItem { Name = "Addresses", Icon = Symbol.ContactInfo, ToolTip = "Addresses" });
        //    NavigationItems.Add(new NavigationItem { Name = "Search", Icon = Symbol.Find, ToolTip = "Search" });
        //    NavigationItems.Add(new NavigationItem { Name = "Publish", Icon = Symbol.Print, ToolTip = "Publish" });
        //    NavigationItems.Add(new NavigationItem { Name = "Tools", Icon = Symbol.Repair, ToolTip = "Tools" });
        //}

        //FooterItems.Clear();
        //FooterItems.Add(new NavigationItem { Name = "Settings", Icon = Symbol.Settings, ToolTip = "Settings" });
    }

    [RelayCommand]
    private void SwitchTab()
    {
        CurrentPage = SelectedNavigationItem.ViewModel;
    }

    public void BuildSearchTerms(MainPageViewModelBase pageItem)
    {
    }

    public void Receive(OpenFileChangedMessage message)
    {
        SetupNavigation();
    }

    private void OnExit(object sender, EventArgs e)
    {
        var json = JsonSerializer.Serialize(_settingService.Settings, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("Settings.json", json);
    }
}