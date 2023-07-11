using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartGenealogy.ViewModels;

public partial class SearchPageViewModel : MainPageViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Search Page View Model Greeting";
}