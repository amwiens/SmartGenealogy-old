using Avalonia.Collections;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using FluentAvalonia.UI.Controls;

using Serilog;

using SmartGenealogy.Contracts;
using SmartGenealogy.Contracts.ViewModels;
using SmartGenealogy.Messages;
using SmartGenealogy.Models;

using System.Collections.ObjectModel;
using System.Text.Json;

using static SmartGenealogy.Localization.Resources;

namespace SmartGenealogy.ViewModels;

public partial class MainWindowViewModel : ObservableRecipient, IMainWindowViewModel, IRecipient<OpenFileChangedMessage>
{
    private readonly ILogger _logger;
    private readonly ISettingService _settingService;

    private readonly IHomeViewModel _homeViewModel;
    private readonly IFileViewModel _fileViewModel;
    private readonly IPeopleViewModel _peopleViewModel;
    private readonly IPlacesViewModel _placesViewModel;
    private readonly ISourcesViewModel _sourcesViewModel;
    private readonly IMediaViewModel _mediaViewModel;
    private readonly ITasksViewModel _tasksViewModel;
    private readonly IAddressesViewModel _addressesViewModel;
    private readonly ISearchViewModel _searchViewModel;
    private readonly IPublishViewModel _publishViewModel;
    private readonly IToolsViewModel _toolsViewModel;
    private readonly ISettingsPageViewModel _settingsViewModel;

    [ObservableProperty]
    private ViewModelBase? _currentPage;

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
        ISettingService settingService,
        ILogger logger)
    {
        _logger = logger;
        _settingService = settingService;

        _homeViewModel = homeViewModel;
        _fileViewModel = fileViewModel;
        _peopleViewModel = peopleViewModel;
        _placesViewModel = placesViewModel;
        _sourcesViewModel = sourcesViewModel;
        _mediaViewModel = mediaViewModel;
        _tasksViewModel = tasksViewModel;
        _addressesViewModel = addressesViewModel;
        _searchViewModel = searchViewModel;
        _publishViewModel = publishViewModel;
        _toolsViewModel = toolsViewModel;
        _settingsViewModel = settingsViewModel;
        
        WeakReferenceMessenger.Default.Register<OpenFileChangedMessage>(this);

        SetupNavigation();
        SelectedNavigationItem = NavigationItems[0];
        SwitchTab();
        _logger.Information("Main Window initialized");
        AppDomain.CurrentDomain.ProcessExit += OnExit!;
    }

    private void SetupNavigation()
    {
        NavigationItems.Clear();
        NavigationItems = new ObservableCollection<NavigationItem>
        {
            new((ViewModelBase)_homeViewModel, XAML_Navigation_Home, "Home", Symbol.Home),
            new((ViewModelBase)_fileViewModel, XAML_Navigation_File, "File", Symbol.Document),
        };

        if (!string.IsNullOrEmpty(_settingService.Settings.FilePath))
        {
            NavigationItems.Add(new((ViewModelBase)_peopleViewModel, XAML_Navigation_People, "People", Symbol.People));
            NavigationItems.Add(new((ViewModelBase)_placesViewModel, XAML_Navigation_Places, "Places", Symbol.Earth));
            NavigationItems.Add(new((ViewModelBase)_sourcesViewModel, XAML_Navigation_Sources, "Sources", Symbol.Library));
            NavigationItems.Add(new((ViewModelBase)_mediaViewModel, XAML_Navigation_Media, "Media", Symbol.Image));
            NavigationItems.Add(new((ViewModelBase)_tasksViewModel, XAML_Navigation_Tasks, "Tasks", Symbol.ShowResults));
            NavigationItems.Add(new((ViewModelBase)_addressesViewModel, XAML_Navigation_Addresses, "Addresses", Symbol.ContactInfo));
            NavigationItems.Add(new((ViewModelBase)_searchViewModel, XAML_Navigation_Search, "Search", Symbol.Find));
            NavigationItems.Add(new((ViewModelBase)_publishViewModel, XAML_Navigation_Publish, "Publish", Symbol.Print));
            NavigationItems.Add(new((ViewModelBase)_toolsViewModel, XAML_Navigation_Tools, "Tools", Symbol.Repair));
        }

        FooterItems.Clear();
        FooterItems = new ObservableCollection<NavigationItem>
        {
            new((ViewModelBase)_settingsViewModel, XAML_Navigation_Settings, "Settings", Symbol.Settings)
        };
    }

    public AvaloniaList<MainAppSearchItem> SearchTerms { get; } = new AvaloniaList<MainAppSearchItem>();

    [RelayCommand]
    private void SwitchTab()
    {
        CurrentPage = SelectedNavigationItem.ViewModel;
        var name = SelectedNavigationItem.Name;
        _logger.Information("Switching content to {Name}", name);
    }

    public void BuildSearchTerms(MainPageViewModelBase pageItem)
    {
    }

    public void Receive(OpenFileChangedMessage message)
    {
        SetupNavigation();
        _logger.Information("Message received: {Message}", message.Value);
    }

    private void OnExit(object sender, EventArgs e)
    {
        var json = JsonSerializer.Serialize(_settingService.Settings, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("Settings.json", json);
        _logger.Information("Settings saved");
    }
}