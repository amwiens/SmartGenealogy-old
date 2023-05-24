namespace SmartGenealogy.Maui.ViewModels;

public class ShellViewModel : ViewModelBase
{
    public AppSection Home { get; set; }
    public AppSection File { get; set; }
    public AppSection People { get; set; }
    public AppSection Places { get; set; }
    public AppSection Sources { get; set; }
    public AppSection Media { get; set; }
    public AppSection Tasks { get; set; }
    public AppSection Addresses { get; set; }
    public AppSection Search { get; set; }
    public AppSection Publish { get; set; }
    public AppSection Tools { get; set; }
    public AppSection Settings { get; set; }

    public ShellViewModel()
    {
        Home = new AppSection() { Title = "Home", Icon = "discover.png", IconDark = "discover_dark.png", TargetType = typeof(HomePage) };
        File = new AppSection() { Title = "File", Icon = "discover.png", IconDark = "discover_dark.png", TargetType = typeof(FilePage) };
        People = new AppSection() { Title = "People", Icon = "discover.png", IconDark = "discover_dark.png", TargetType = typeof(PeoplePage) };
        Places = new AppSection() { Title = "Places", Icon = "discover.png", IconDark = "discover_dark.png", TargetType = typeof(PlacesPage) };
        Sources = new AppSection() { Title = "Sources", Icon = "discover.png", IconDark = "discover_dark.png", TargetType = typeof(SourcesPage) };
        Media = new AppSection() { Title = "Media", Icon = "discover.png", IconDark = "discover_dark.png", TargetType = typeof(MediaPage) };
        Tasks = new AppSection() { Title = "Tasks", Icon = "discover.png", IconDark = "discover_dark.png", TargetType = typeof(TasksPage) };
        Addresses = new AppSection() { Title = "Addresses", Icon = "discover.png", IconDark = "discover_dark.png", TargetType = typeof(AddressesPage) };
        Search = new AppSection() { Title = "Search", Icon = "discover.png", IconDark = "discover_dark.png", TargetType = typeof(SearchPage) };
        Publish = new AppSection() { Title = "Publish", Icon = "discover.png", IconDark = "discover_dark.png", TargetType = typeof(PublishPage) };
        Tools = new AppSection() { Title = "Tools", Icon = "discover.png", IconDark = "discover_dark.png", TargetType = typeof(ToolsPage) };
        Settings = new AppSection() { Title = "Settings", Icon = "settings.png", IconDark = "settings_dark.png", TargetType = typeof(SettingsPage) };
    }
}