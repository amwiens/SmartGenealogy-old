using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartGenealogy.ViewModels;

public partial class MainPageViewModelBase : ViewModelBase
{
    [ObservableProperty]
    public string? _navHeader;

    public string? IconKey { get; set; }

    public bool ShowsInFooter { get; set; }
}