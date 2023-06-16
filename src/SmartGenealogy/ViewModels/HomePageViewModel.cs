using SmartGenealogy.Maui.Navigation;

namespace SmartGenealogy;

public partial class HomePageViewModel : NavigationAwareBaseViewModel
{
    public HomePageViewModel(IAppNavigator appNavigator)
        : base(appNavigator)
    {
    }
}