using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartGenealogy.ViewModels;

public partial class SettingsPageViewModel : MainPageViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Settings Page View Model Greeting";

    public SettingsPageViewModel()
    {
    }
}