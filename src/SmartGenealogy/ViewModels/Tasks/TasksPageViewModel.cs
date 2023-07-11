using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartGenealogy.ViewModels;

public partial class TasksPageViewModel : MainPageViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Tasks Page View Model Greeting";
}