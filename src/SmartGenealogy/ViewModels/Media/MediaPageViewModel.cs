using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartGenealogy.ViewModels;

public partial class MediaPageViewModel : MainPageViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Media Page View Model Greeting";
}