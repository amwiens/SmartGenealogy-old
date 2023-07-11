using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartGenealogy.ViewModels;

public partial class SourcesPageViewModel : MainPageViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Sources Page View Model Greeting";
}