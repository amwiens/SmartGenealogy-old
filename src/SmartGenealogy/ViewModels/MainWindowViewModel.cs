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

using static SmartGenealogy.Localization.Resources;

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
            new((ViewModelBase)homeViewModel, XAML_Navigation_Home, "Home", Symbol.Home),
            new((ViewModelBase)fileViewModel, XAML_Navigation_File, "File", Symbol.Document),
            new((ViewModelBase)peopleViewModel, XAML_Navigation_People, "People", Symbol.People),
            new((ViewModelBase)placesViewModel, XAML_Navigation_Places, "Places", Symbol.Earth),
            new((ViewModelBase)sourcesViewModel, XAML_Navigation_Sources, "Sources", Symbol.Library),
            new((ViewModelBase)mediaViewModel, XAML_Navigation_Media, "Media", Symbol.Image),
            new((ViewModelBase)tasksViewModel, XAML_Navigation_Tasks, "Tasks", Symbol.ShowResults),
            new((ViewModelBase)addressesViewModel, XAML_Navigation_Addresses, "Addresses", Symbol.ContactInfo),
            new((ViewModelBase)searchViewModel, XAML_Navigation_Search, "Search", Symbol.Find),
            new((ViewModelBase)publishViewModel, XAML_Navigation_Publish, "Publish", Symbol.Print),
            new((ViewModelBase)toolsViewModel, XAML_Navigation_Tools, "Tools", Symbol.Repair)
        };

        FooterItems = new ObservableCollection<NavigationItem>
        {
            new((ViewModelBase)settingsViewModel, XAML_Navigation_Settings, "Settings", Symbol.Settings)
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