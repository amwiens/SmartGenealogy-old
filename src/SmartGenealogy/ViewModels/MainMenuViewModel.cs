namespace SmartGenealogy.ViewModels;

public partial class MainMenuViewModel : BaseViewModel
{
    private readonly INavigation _navigation;
    private readonly Action<Page> _openPageAsRoot;

    [ObservableProperty]
    private List<MenuEntry> _mainMenuEntries;

    [ObservableProperty]
    private MenuEntry _mainMenuSelectedItem;

    partial void OnMainMenuSelectedItemChanging(MenuEntry? oldValue, MenuEntry newValue)
    {
        if (SetProperty(ref oldValue, newValue) && newValue != null)
        {
            NavigationPage navigationPage = new NavigationPage((Page)Activator.CreateInstance(newValue.TargetType));

            _openPageAsRoot(navigationPage);

            MainMenuSelectedItem = null;
            OnPropertyChanged(nameof(MainMenuSelectedItem));
        }
    }

    public MainMenuViewModel(INavigation navigation, Action<Page> openPageAsRoot)
    {
        _navigation = navigation;
        _openPageAsRoot = openPageAsRoot;

        WeakReferenceMessenger.Default.Register<CultureChangeMessage>(this);

        LoadMenuData();

        var firstEntry = MainMenuEntries[0];
        MainMenuSelectedItem = firstEntry;
    }

    /// <summary>
    /// On received culture changed message, reload Menu item
    /// </summary>
    /// <param name="message"></param>
    public override void Receive(CultureChangeMessage message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            LoadMenuData();
        });
    }

    private void LoadMenuData()
    {
        MainMenuEntries = new List<MenuEntry>
        {
            new MenuEntry
            {
                Title = LocalizationResourceManager.Translate("MenuMainHome"),
                Icon = MaterialDesignIcons.Home,
                TargetType = typeof(HomePage)
            },
            new MenuEntry
            {
                Title = LocalizationResourceManager.Translate("MenuMainFile"),
                Icon = MaterialDesignIcons.Pageview,
                TargetType = typeof(FilePage)
            },
            new MenuEntry
            {
                Title = LocalizationResourceManager.Translate("MenuMainPeople"),
                Icon = MaterialDesignIcons.People,
                TargetType = typeof(PeoplePage)
            },
            new MenuEntry
            {
                Title = LocalizationResourceManager.Translate("MenuMainPlaces"),
                Icon = MaterialDesignIcons.Place,
                TargetType = typeof(PlacesPage)
            },
            new MenuEntry
            {
                Title = LocalizationResourceManager.Translate("MenuMainSources"),
                Icon = MaterialDesignIcons.Tablet,
                TargetType = typeof(SourcesPage)
            },
            new MenuEntry
            {
                Title = LocalizationResourceManager.Translate("MenuMainMedia"),
                Icon = MaterialDesignIcons.Image,
                TargetType = typeof(MediaPage)
            },
            new MenuEntry
            {
                Title = LocalizationResourceManager.Translate("MenuMainTasks"),
                Icon = MaterialDesignIcons.CheckBox,
                TargetType = typeof(TasksPage)
            },
            new MenuEntry
            {
                Title = LocalizationResourceManager.Translate("MenuMainAddresses"),
                Icon = MaterialDesignIcons.Mail,
                TargetType = typeof(AddressesPage)
            },
            new MenuEntry
            {
                Title = LocalizationResourceManager.Translate("MenuMainSearch"),
                Icon = MaterialDesignIcons.Search,
                TargetType = typeof(SearchPage)
            },
            new MenuEntry
            {
                Title = LocalizationResourceManager.Translate("MenuMainPublish"),
                Icon = MaterialDesignIcons.Print,
                TargetType = typeof(PublishPage)
            },
            new MenuEntry
            {
                Title = LocalizationResourceManager.Translate("MenuMainTools"),
                Icon = MaterialDesignIcons.Dashboard,
                TargetType = typeof(ToolsPage)
            },
            new MenuEntry
            {
                Title = LocalizationResourceManager.Translate("MenuMainChat"),
                Icon = MaterialDesignIcons.Chat,
                TargetType = typeof(ChatDetailPage)
            },
            new MenuEntry
            {
                Title = LocalizationResourceManager.Translate("MenuMainSettings"),
                Icon = MaterialDesignIcons.Settings,
                TargetType = typeof(SettingsPage)
            },
            new MenuEntry
            {
                Title = LocalizationResourceManager.Translate("MenuMainAbout"),
                Icon = MaterialDesignIcons.Info,
                TargetType = typeof(AboutPage)
            }
        };
    }
}