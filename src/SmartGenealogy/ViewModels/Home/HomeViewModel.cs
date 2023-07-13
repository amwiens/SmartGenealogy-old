using CommunityToolkit.Mvvm.ComponentModel;

using SmartGenealogy.Contracts.ViewModels;

namespace SmartGenealogy.ViewModels.Home;

public partial class HomeViewModel : MainPageViewModelBase, IHomeViewModel
{
    [ObservableProperty]
    private List<HomeNavPageViewModel> _pages = new List<HomeNavPageViewModel>();

    public HomeViewModel()
    {
        Pages = new List<HomeNavPageViewModel>()
        {
            new HomeNavPageViewModel("Documentation", new Uri("https://amwx.github.io/FluentAvaloniaDocs"))
            {
                ImageUri = "avares://SmartGenealogy/Resources/Images/Documentation.png"
            }
        };
    }
}