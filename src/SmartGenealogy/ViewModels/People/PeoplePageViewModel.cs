using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartGenealogy.ViewModels;

public partial class PeoplePageViewModel : MainPageViewModelBase
{
    [ObservableProperty]
    private string _greeting = "People Page View Model Greeting";
}