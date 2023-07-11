using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartGenealogy.ViewModels;

public partial class PlacesPageViewModel : MainPageViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Places Page View Model Greeting";
}