using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartGenealogy.ViewModels;

public partial class PublishPageViewModel : MainPageViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Publish Page View Model Greeting";
}