using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartGenealogy.ViewModels;

public partial class FilePageViewModel : MainPageViewModelBase
{
    [ObservableProperty]
    private string _greeting = "File Page View Model Greeting";
}