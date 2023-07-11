using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartGenealogy.ViewModels;

public partial class HomePageViewModel : MainPageViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Home Page View Model Greeting";
}