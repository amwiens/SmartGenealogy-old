using SmartGenealogy.Maui.Navigation;

namespace SmartGenealogy.ViewModels;

public partial class HomePageViewModel : NavigationAwareBaseViewModel
{
    public HomePageViewModel(IAppNavigator appNavigator)
        : base(appNavigator)
    {
    }
}