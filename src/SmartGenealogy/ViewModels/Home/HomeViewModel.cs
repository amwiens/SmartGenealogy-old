using CommunityToolkit.Mvvm.ComponentModel;

using Serilog;

using SmartGenealogy.Contracts.ViewModels;

using static SmartGenealogy.Localization.Resources;

namespace SmartGenealogy.ViewModels.Home;

public partial class HomeViewModel : MainPageViewModelBase, IHomeViewModel
{
    private readonly ILogger _logger;

    [ObservableProperty]
    private List<HomeNavPageViewModel> _pages = new List<HomeNavPageViewModel>();

    public HomeViewModel(ILogger logger)
    {
        _logger = logger;

        Pages = new List<HomeNavPageViewModel>()
        {
            new HomeNavPageViewModel("Documentation", new Uri("https://amwx.github.io/FluentAvaloniaDocs"))
            {
                ImageUri = "avares://SmartGenealogy/Resources/Images/Documentation.png"
            }
        };

        NavHeader = XAML_Navigation_Home;

        _logger.Information("Home view model initialized");
    }
}