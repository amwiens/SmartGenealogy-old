using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartGenealogy.ViewModels;

public partial class ToolsPageViewModel : MainPageViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Tools Page View Model Greeting";
}