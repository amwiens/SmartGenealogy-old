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

namespace SmartGenealogy.ViewModels;

public partial class MainWindowViewModel : ObservableRecipient, IMainWindowViewModel, IRecipient<OpenFileChangedMessage>
{
    private readonly ILogger _logger;
    private readonly ISettingService _settingService;

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
        ISettingService settingService,
        ILogger logger)
    {
        _logger = logger;
        _settingService = settingService;
        
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
        _logger.Information("Main Window initialized");
        AppDomain.CurrentDomain.ProcessExit += OnExit!;
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
        //SetupNavigation();
        _logger.Information("Message received: {Message}", message.Value);
    }

    private void OnExit(object sender, EventArgs e)
    {
        var json = JsonSerializer.Serialize(_settingService.Settings, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("Settings.json", json);
        _logger.Information("Settings saved");
    }
}