namespace SmartGenealogy.ViewModels;

public class MainMenuViewModel : ObservableObject, IRecipient<CultureChangeMessage>
{
    private readonly INavigation _navigation;
    private readonly Action<Page> _openPageAsRoot;
    private List<MenuEntry> _mainMenuEntries;
    private MenuEntry _selectedMainMenuEntry;

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
    public void Receive(CultureChangeMessage message)
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
                Title = LocalizationResourceManager.Translate("MenuMainSettings"),
                Icon = MaterialDesignIcons.Settings,
                TargetType = typeof(SettingsPage)
            }
        };
    }

    public List<MenuEntry> MainMenuEntries
    {
        get { return _mainMenuEntries; }
        set { SetProperty(ref _mainMenuEntries, value); }
    }

    public MenuEntry MainMenuSelectedItem
    {
        get { return _selectedMainMenuEntry; }
        set
        {
            if (SetProperty(ref _selectedMainMenuEntry, value) && value != null)
            {
                NavigationPage navigationPage = new NavigationPage((Page)Activator.CreateInstance(value.TargetType));

                _openPageAsRoot(navigationPage);

                _selectedMainMenuEntry = null;
                OnPropertyChanged(nameof(MainMenuSelectedItem));
            }
        }
    }
}