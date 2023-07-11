using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartGenealogy.ViewModels;

public partial class AddressesPageViewModel : MainPageViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Addresses Page View Model Greeting";
}