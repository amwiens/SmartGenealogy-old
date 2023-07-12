using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartGenealogy.ViewModels;

public partial class HomePageViewModel : MainPageViewModelBase
{
    [ObservableProperty]
    private List<HomeNavPageViewModel> _pages = new List<HomeNavPageViewModel>();

    public HomePageViewModel()
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